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
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository):base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<Cliente> ObterClientesEspecias(IEnumerable<Cliente> clientes)
        {
            return clientes.Where(c => c.ClientesEspeciais(c));//repository ñ tem esse método por isso chama c/ cliente, retorna uma lista de cliente e passa uma lista tb  
        }
    }
}
