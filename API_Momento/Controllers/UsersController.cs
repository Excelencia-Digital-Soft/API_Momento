using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API_Momento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        private IUsersServices _usersServices;

        public UsersController(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        [Authorize]
        [HttpGet("perfil-publico")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Respuesta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        public async Task<IActionResult> perfilPublico(int idUser)
        {
            var resp = await _usersServices.GetUserByIdUser(idUser);

            if (resp.Success) 
                return new OkObjectResult(resp);

            return new BadRequestObjectResult(resp);
        }
    }
}
