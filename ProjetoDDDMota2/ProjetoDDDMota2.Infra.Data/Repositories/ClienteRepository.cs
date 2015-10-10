using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoDDDMota2.Domain.Entities;
using ProjetoDDDMota2.Infra.Data.Repositories;
using ProjetoDDDMota2.Domain.Interfaces.Repositories;

namespace ProjetoDDDMota2.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
    }
}
