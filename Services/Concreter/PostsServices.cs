using PostsData = Domain.DTOs.PostsData;
using Domain;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services.Concreter
{
    public class PostsServices: IPostsServices
    {
        private IPostsRepository _postsrepository;
        private IExceptionsServices _exceptionsservices;

        public PostsServices(IPostsRepository postsRepository, IExceptionsServices exceptionsservices)
        {
            _postsrepository = postsRepository;
            _exceptionsservices = exceptionsservices;
        }

        public async Task<Respuesta> GetAllPostsByIdUser(int IdUser)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Message = "Posts";
            try
            {
                var posts = await _postsrepository.GetAllPosts(IdUser);
                if (posts is null || !posts.Any())
                    throw new Exception($"No se encontraron publicaciones");

                // Mapeo de las publicaciones a objetos PostsData
                var postsDataList = posts.Select(post => new PostsData
                {
                    IdPublication = post.IdPublication,
                    Picture = post.Picture,
                    Text = post.Text,
                    PictureByte = post.PictureByte,
                    CreationDate = post.CreationDate,
                    CreationDateString = post.CreationDateString,
                    AgoDate = CalculateAgoDate(post.CreationDate)
                }).ToList();

                respuesta.Success = true;
                respuesta.Data = postsDataList;
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Message = $"Error al obtener publicaciones: {ex.Message}";
                respuesta.Data = null;
            }

            return respuesta;
        }

        private string CalculateAgoDate(DateTime creationDate)
        {

            TimeSpan difference = DateTime.Now - creationDate;
            if (difference.TotalHours < 24)
            {
                return $"Hace {difference.TotalHours} horas";
            }
            else
            {
                return $"Hace {difference.TotalDays} días";
            }
        }

    }

}
