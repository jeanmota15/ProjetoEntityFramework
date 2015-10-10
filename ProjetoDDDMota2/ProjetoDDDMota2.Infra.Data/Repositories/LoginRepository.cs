using ProjetoDDDMota2.Domain.Entities;
using ProjetoDDDMota2.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDDMota2.Infra.Data.Repositories
{
    public class LoginRepository : RepositoryBase<Login>, ILoginRepository
    {
        public Login Logar(string usuario, string senha)
        {
            return Db.Logins.Where(x => x.Usuario == usuario && x.Senha == senha).FirstOrDefault();
        }
    }
}
