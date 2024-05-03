using Domain.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ILoginServices
    {
        Task<Respuesta> Register(UserRegisterDTO reg);
        Task<Respuesta> SingIn(SingIn singIn);
    }
}
