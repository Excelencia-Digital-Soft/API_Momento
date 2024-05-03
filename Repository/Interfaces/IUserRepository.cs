using Models.MomentoApp;


namespace Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByName(string name);
        Task<User> GetUserByEmail(string Mail);
        Task<User> GetUserByCuil(string cuil);
    }
}
