using Domain;
using Domain.DTOs;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.MomentoApp;
using Repository.Interfaces;
using Services.Interfaces;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;



namespace Services.Concreter
{
    public class LoginServices : ILoginServices
    {
        private IConfiguration _configuration;
        private IPasswordHasher _passwordHasher;
        private IUserRepository _userRepository;
        private IUserAuditRepository _userAuditRepository;
        private IUserPictureRepository _userPictureRepository;
        
        public LoginServices(IConfiguration configuration, IUserRepository userRepository,IUserAuditRepository userAuditRepository, IUserPictureRepository userPictureRepository)
        {
            _passwordHasher = new PasswordHasher();
            _configuration = configuration;
            _userRepository = userRepository;
            _userAuditRepository = userAuditRepository;
            _userPictureRepository = userPictureRepository;
        }

        public async Task<Respuesta> Register(UserRegisterDTO reg)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Message = "Registro Usuario";
            try
            {
                var valido = await ValidarRegistro(reg);
                if (valido == "")
                {
                    var sha = ShaHash(reg.Pass);
                    var hashPass = _passwordHasher.HashPassword(sha);

                    var newUser = new User
                    {
                        Mail = reg.Mail,
                        Username = reg.Username,
                        Pass = hashPass,
                        BirthDate = reg.BirthDate,
                        IdRole = 1,
                        Annulated = false,
                        NameFull = reg.NameFull,
                        Cuil = reg.Cuil,
                        MailVerification = false,
                        Description = ""
                    };

                    _userRepository.Insert(newUser);
                    _userRepository.Save();

                    registroAuditoriaCrea(newUser.IdUser);

                    respuesta.Success = true;
                    respuesta.Data = "Usuario Registrado";
                }else
                {
                    respuesta.Success = false;
                    respuesta.Data = "El Usuario ya se encuentra registrado";
                }
                
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Data = ex.Message;
                
            }
            return respuesta;

        }

        public async Task<string> ValidarRegistro(UserRegisterDTO reg)
        {
            try { 
            var nameTask  =  _userRepository.GetUserByName(reg.Username);
            var emailTask =  _userRepository.GetUserByEmail(reg.Mail);
            var cuilTask  =  _userRepository.GetUserByCuil(reg.Cuil);

                var name = await nameTask;
               if(name is not null)
                    throw new Exception($"Ya hay un usuario registrado con este Correo");

                var email = await emailTask;
                if (email is not null)
                    throw new Exception($"Ya hay un usuario registrado con este Nombre");

                var cuil = await cuilTask;
                if (cuil is not null)
                    throw new Exception($"Ya hay un usuario registrado con este Nombre");

             return "";
            }catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task registroAuditoriaCrea(int idUser)
        {
            var UserAudit = new UsersAudit
            {
                IdUser = idUser,
                Creationdate = DateTime.Now,
            };

            _userAuditRepository.Insert(UserAudit);
            _userAuditRepository.Save();
        }

        public async Task<Respuesta> SingIn(SingIn singIn)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Message = "Sing In";
            User user = null;
            try
            {
                string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                //USER
                if (Regex.IsMatch(singIn.User, patron))
                    user = await _userRepository.GetUserByEmail(singIn.User);
                if (singIn.User.Length == 11)
                    user = await _userRepository.GetUserByCuil(singIn.User);
                

                if (user is null)
                    throw new Exception($"Usuario no encontrado");

                if(user.Annulated)
                    throw new Exception($"Usuario Anulado");

                //PASS
                var sha = ShaHash(singIn.Password);
                //var hashPass = _passwordHasher.HashPassword(sha);
                var res = _passwordHasher.VerifyHashedPassword(user.Pass, sha);
                if (res == PasswordVerificationResult.Failed)
                    throw new Exception($"La Contraseña no es valida.");
                
                //TOKEN
                string token = GetToken(user);
                
                //Edad
                var age = DateTime.Now - user.BirthDate;
                int edadEnAnios = (int)(age.Days / 365.25);

                //Photo
                var photo = await _userPictureRepository.GetUserPictureByIdUser(user.IdUser); 
                RespuestaSingIn Data = new RespuestaSingIn
                {
                    Token = token,
                    IdUser = user.IdUser,
                    Username = user.Username,
                    NameFull = user.NameFull,
                    Cuil = user.Cuil,
                    Mail = user.Mail,
                    IdRole = user.IdRole,
                    BirthDate = user.BirthDate,
                    Age = edadEnAnios,
                    UserPhoto = photo.FileCod,
                    FormatPhoto = photo.FileFormat ?? ""
                };

                respuesta.Success = true;
                respuesta.Data = Data;

            }catch(Exception ex)
            {
                respuesta.Success = false;
                respuesta.Data = ex.Message;
                
            }
            return respuesta;
        }

        public string GetToken(User user) 
        {
            var jwtSettingsSub = _configuration.GetSection("Jwt:Subject").Value;
            var jwtSettingsKey = _configuration.GetSection("Jwt:Key").Value;


            var tokenHandler = new JwtSecurityTokenHandler();
            var bytekey = Encoding.UTF8.GetBytes(jwtSettingsKey);

            var tokenDes = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                            new Claim(JwtRegisteredClaimNames.Name, user.NameFull),
                            new Claim(JwtRegisteredClaimNames.Email,user.Mail),
                            new Claim("Id", user.IdUser.ToString()),
                            new Claim(ClaimTypes.Role, user.IdRole.ToString()),
                        }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(bytekey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDes);

            return tokenHandler.WriteToken(token);
        }

        public string ShaHash(string rawData)
        {
            // Create a SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
