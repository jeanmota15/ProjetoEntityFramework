using ProjetoDDDMota2.Application.Interfaces.Services;
using ProjetoDDDMota2.Domain.Entities;
using ProjetoDDDMota2.Domain.Interfaces.Repositories;
using ProjetoDDDMota2.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDDMota2.Application.Services
{
    public class LoginAppService : AppServiceBase<Login>, ILoginAppService
    {
        private ILoginService _loginService;

        public LoginAppService(ILoginService loginService) :base(loginService)
        {
            _loginService = loginService;
        }

        public Login Logar(string usuario, string senha)
        {
            return _loginService.Logar(usuario, senha);
        }
    }
}
