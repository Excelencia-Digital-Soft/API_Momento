using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;


namespace API_Momento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
  
        private ILoginServices _loginServices;
        public LoginController(ILoginServices loginServices)
        {
            
            _loginServices = loginServices;
        }

        [HttpPost("SingIn")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Respuesta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        public async Task<IActionResult> SingIn(SingIn singIn)
        {

            var result = await _loginServices.SingIn(singIn);
            if(result.Success)
               return new OkObjectResult(result);

            return new BadRequestObjectResult(result);
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Respuesta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        public async Task<IActionResult> Register(UserRegisterDTO reg)
        {

            var result = await _loginServices.Register(reg);

            if (result.Success)
                return new OkObjectResult(result);

            return new BadRequestObjectResult(result);
        }


    }
}
