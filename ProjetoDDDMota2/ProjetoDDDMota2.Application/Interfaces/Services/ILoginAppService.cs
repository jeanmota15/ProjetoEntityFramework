using ProjetoDDDMota2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDDMota2.Application.Interfaces.Services
{
    public interface ILoginAppService : IAppServiceBase<Login>
    {
        Login Logar(string usuario, string senha);
    }
}
