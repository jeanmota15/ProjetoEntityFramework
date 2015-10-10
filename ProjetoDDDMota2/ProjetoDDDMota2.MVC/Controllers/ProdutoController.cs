using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoDDDMota2.Domain.Entities;
using ProjetoDDDMota2.MVC.ViewModels;
using AutoMapper;
using ProjetoDDDMota2.Application.Interfaces.Services;
using ProjetoDDDMota2.MVC.AutoMapper;

namespace ProjetoDDDMota2.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutoAppService _produtoService;
        private IClienteAppService _clienteService;

        public ProdutoController(IProdutoAppService produtoService, IClienteAppService clienteService)
        {
            _produtoService = produtoService;
            _clienteService = clienteService;
        }

        public ActionResult Index(string nome, string ordem)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var produto = _produtoService.GetAll();
            var produtoLista = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(produto);

            foreach (var item in produtoLista)
            {
                if (item.Valor <= 10)
                {
                    item.Valor = item.Valor + 10;
                }
            }

            ViewBag.Nome = string.IsNullOrEmpty(ordem) ? "Nome_Desc" : "Nome";
            ViewBag.Date = ordem == "Date" ? "Data_Desc" : "Date";

            if (!string.IsNullOrEmpty(nome))
            {
                produtoLista = produtoLista.Where(x => x.Cliente.Nome.ToUpper().Contains(nome.ToUpper())
                || x.Nome.ToUpper().Contains(nome.ToUpper())).ToList();
            }

            switch (ordem)
            {
                case "Nome_Desc":
                    produtoLista = produtoLista.OrderByDescending(x => x.Cliente.Nome).ToList();
                    break;
                case "Nome":
                    produtoLista = produtoLista.OrderBy(x => x.Cliente.Nome).ToList();
                    break;
                case "Data_Desc":
                    produtoLista = produtoLista.OrderByDescending(x => x.Cliente.DataCadastro).ToList();
                    break;
                case "Date":
                    produtoLista = produtoLista.OrderBy(x => x.Cliente.DataCadastro).ToList();
                    break;
                default:
                    produtoLista = produtoLista.OrderBy(x => x.Cliente.Nome).ToList();
                    break;
            }

            return View(produtoLista);
        }

        public ActionResult Index2(string pesquisa)
        {

            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var produto = _produtoService.GetAll();
            var produtoLista = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(produto);

            ViewBag.Pesquisa = (from p in produtoLista
                                   select p.Cliente.Nome).Distinct();

            var model = from p in produtoLista
                        orderby p.Cliente.Nome
                        where p.Cliente.Nome == pesquisa
                        select p;

            return View(model);
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {

            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var produto = _produtoService.GetById(id);
            var produtoId = Mapper.Map<Produto, ProdutoViewModel>(produto);

            if (produtoId == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(produtoId);
            }
        }

        // GET: Produto/Create
        public ActionResult Create()
        {

            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.ClienteId = new SelectList(_clienteService.GetAll(), "ClienteId", "Nome");
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoCreate = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoService.Add(produtoCreate);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ClienteId = new SelectList(_clienteService.GetAll(), "ClienteId", "Nome", produto.ClienteId);
                return View(produto);
            }    
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {

            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var produto = _produtoService.GetById(id);//do getbyid
            var produtoId = Mapper.Map<Produto, ProdutoViewModel>(produto);

            if (produtoId == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.ClienteId = new SelectList(_clienteService.GetAll(), "ClienteId", "Nome", produto.ClienteId);
                return View(produtoId);
            }
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoEdit = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoService.Update(produtoEdit);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ClienteId = new SelectList(_clienteService.GetAll(), "ClienteId", "Nome", produto.ClienteId);
                return View(produto);
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {

            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var produto = _produtoService.GetById(id);
            var produtoId = Mapper.Map<Produto, ProdutoViewModel>(produto);

            if (produtoId == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(produtoId);
            }
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmded(int id)
        {
            var produto = _produtoService.GetById(id);
            _produtoService.Remove(produto);
            return RedirectToAction("Index");
        }
    }
}
