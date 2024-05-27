using Models.MomentoApp;


namespace Repository.Interfaces
{
    public interface IPostsRepository : IBaseRepository<PostsData>
    {
        Task<List<PostsData>> GetAllPosts(int idUser);
        //Task<User> GetUserByEmail(string Mail);
        //Task<User> GetUserByCuil(string cuil);
    }
}
