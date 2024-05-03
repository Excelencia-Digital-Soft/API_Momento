
using Models.MomentoApp;
using Repository.Interfaces;

namespace Repository.Concreter
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MomentosAppContext _context) : base(_context)
        {
            
        }

        public async Task<User> GetUserByName (string name)
        {
            return table.Where(u => u.Username == name.Trim() && !u.Annulated).FirstOrDefault() ?? null;
        }

        public async Task<User> GetUserByEmail(string Mail)
        {
            return table.Where(u => u.Mail == Mail.Trim() && !u.Annulated).FirstOrDefault() ?? null;
        }

        public async Task<User> GetUserByCuil(string cuil)
        {
            return table.Where(u => u.Cuil == cuil && !u.Annulated).FirstOrDefault() ?? null;
        }
    }
}
