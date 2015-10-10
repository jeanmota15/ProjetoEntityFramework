using ProjetoDDDMota2.Domain.Entities;
using ProjetoDDDMota2.Domain.Interfaces.Repositories;
using ProjetoDDDMota2.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDDMota2.Domain.Services
{
    public class LoginService : ServiceBase<Login>, ILoginService
    {
        private ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository):base(loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public Login Logar(string usuario, string senha)
        {
            return _loginRepository.Logar(usuario, senha);
        }
    }
}
