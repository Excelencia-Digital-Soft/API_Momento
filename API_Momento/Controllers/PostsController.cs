using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API_Momento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PostsController : ControllerBase
    {
        private IPostsServices _postsServices;

        public PostsController(IPostsServices postsServices)
        {
            _postsServices = postsServices;
        }

        //[Authorize]
        [HttpGet("all-posts-user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Respuesta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        public async Task<IActionResult> GetAllPostsByIdUser(int idUser)
        {
            var resp = await _postsServices.GetAllPostsByIdUser(idUser);

            if (resp.Success) 
                return new OkObjectResult(resp);

            return new BadRequestObjectResult(resp);
        }
    }
}
