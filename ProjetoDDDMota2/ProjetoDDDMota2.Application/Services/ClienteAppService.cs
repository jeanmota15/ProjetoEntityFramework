using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoDDDMota2.Application.Interfaces.Services;
using ProjetoDDDMota2.Domain.Interfaces.Repositories;
using ProjetoDDDMota2.Domain.Entities;
using ProjetoDDDMota2.Domain.Interfaces.Services;

namespace ProjetoDDDMota2.Application.Services
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService) :base(clienteService)
        {
            _clienteService = clienteService;
        }

        public IEnumerable<Cliente> ObterClientesEspeciais()
        {
            return _clienteService.ObterClientesEspecias(_clienteService.GetAll());
        }
    }
}
