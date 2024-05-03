using Domain.DTOs;
using Domain;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services.Concreter
{
    public class UsersServices: IUsersServices
    {
        private IUserRepository _userrepository;
        private IUserPictureRepository _userpicturerepository;
        private IExceptionsServices _exceptionsservices;

        public UsersServices(IUserRepository userRepository, IUserPictureRepository userPictureRepository, IExceptionsServices exceptionsservices)
        {
            _userrepository = userRepository;
            _userpicturerepository = userPictureRepository;
            _exceptionsservices = exceptionsservices;
        }

        public async Task<Respuesta> GetUserByIdUser(int IdUser)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Message = "User";
            try
            {
                var user = _userrepository.GetById(IdUser);
                if (user is null)
                    throw new Exception($"No se encontro el usuario");

                var userPicture = await _userpicturerepository.GetUserPictureByIdUser(IdUser);

                var dataUser = new UserData
                {
                    NameFull = user.NameFull,
                    Username = user.Username,
                    UserPhoto = userPicture.FileCod
                };

                respuesta.Success = true;
                respuesta.Data = dataUser;
            }
            catch (Exception ex)
            {
                respuesta.Success = true;
                respuesta.Data = ex.Message;

            }

            return respuesta;
        }
    }
}
