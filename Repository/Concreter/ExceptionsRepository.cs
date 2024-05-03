using Models.MomentoApp;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concreter
{
    public class ExceptionsRepository : BaseRepository<ExceptionLogs>, IExceptionsRepository
    {
        public ExceptionsRepository(MomentosAppContext _context) : base(_context)
        {
            
        }
    }
}
