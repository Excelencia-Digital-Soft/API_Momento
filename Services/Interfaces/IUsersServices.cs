using Domain;

namespace Services.Interfaces
{
    public interface IUsersServices
    {
        Task<Respuesta> GetUserByIdUser(int IdUser);
    }
}
