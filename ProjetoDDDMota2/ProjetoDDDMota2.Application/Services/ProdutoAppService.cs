using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoDDDMota2.Domain.Entities;
using ProjetoDDDMota2.Application.Interfaces.Services;
using ProjetoDDDMota2.Domain.Interfaces.Services;

namespace ProjetoDDDMota2.Application.Services
{
    public class ProdutoAppService : AppServiceBase<Produto>, IProdutoAppService
    {
        private IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService):base(produtoService)
        {
            _produtoService = produtoService;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoService.BuscarPorNome(nome);
        }
    }
}
