using Domain;

namespace Services.Interfaces
{
    public interface IPostsServices
    {
        Task<Respuesta> GetAllPostsByIdUser(int IdUser);
    }
}
