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
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository):base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoRepository.BuscarPorNome(nome);
        }
    }
}
