using Domain.DTOs.Exeptions;
using Repository.Interfaces;
using Services.Interfaces;


namespace Services.Concreter
{
    public class ExceptionsServices : IExceptionsServices
    {
        private IExceptionsRepository _exceptionsRepository;

        public ExceptionsServices(IExceptionsRepository exceptionsRepository)
        {
            _exceptionsRepository = exceptionsRepository;
        }

        public async Task SaveException(ExceptionDTO eDTO)
        {

        }
    }
}
