using Microsoft.EntityFrameworkCore;
using Models.MomentoApp;
using Repository.Interfaces;


namespace Repository.Concreter
{
    public class UserPictureRepository : BaseRepository<UserPicture>, IUserPictureRepository
    {
        public UserPictureRepository(MomentosAppContext _context) : base(_context)
        {
            
        }

        public async Task<UserPicture> GetUserPictureByIdUser(int IdUser)
        {
            return await table.FirstOrDefaultAsync(up => up.IdUser == IdUser) ?? new UserPicture();
        }
    }
}
    