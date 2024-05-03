using Models.MomentoApp;
using Repository.Interfaces;


namespace Repository.Concreter
{
    public class UserAuditRepository : BaseRepository<UsersAudit>,IUserAuditRepository
    {
        public UserAuditRepository(MomentosAppContext _context) : base(_context)
        {
            
        }

        
    }
}
