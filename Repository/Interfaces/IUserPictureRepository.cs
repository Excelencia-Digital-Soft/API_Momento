using Models.MomentoApp;


namespace Repository.Interfaces
{
    public interface IUserPictureRepository : IBaseRepository<UserPicture>
    {
        Task<UserPicture> GetUserPictureByIdUser(int IdUser);
    }
}
