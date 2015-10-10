using ProjetoDDDMota2.Domain.Entities;
using ProjetoDDDMota2.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDDMota2.Domain.Interfaces.Services
{
    public interface ILoginService : IServiceBase<Login>
    {

        Login Logar(string usuario, string senha);
    }
}
