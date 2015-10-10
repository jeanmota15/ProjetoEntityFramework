using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoDDDMota2.Domain.Entities;
using AutoMapper;
using ProjetoDDDMota2.Application.Interfaces.Services;
using ProjetoDDDMota2.MVC.ViewModels;

namespace ProjetoDDDMota2.MVC.Controllers
{
    public class ClienteController : Controller
    {
        private IClienteAppService _clienteService;

        public ClienteController(IClienteAppService clienteService)
        {
            _clienteService = clienteService;
        }

        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var cliente = _clienteService.GetAll();
            var clienteLista = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(cliente);
            return View(clienteLista);
        }

        public ActionResult Especiais()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var cliente = _clienteService.ObterClientesEspeciais();
            var clienteLista = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(cliente);
            return View(clienteLista);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var cliente = _clienteService.GetById(id);
            var clienteId = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            if (clienteId == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(clienteId);
            } 
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteCreate = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteService.Add(clienteCreate);
                return RedirectToAction("Index");
            }
            else
            {
                return View(cliente);
            }   
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var cliente = _clienteService.GetById(id);
            var clienteId = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            if (clienteId == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(clienteId);
            }
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteEdit = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteService.Update(clienteEdit);
                return RedirectToAction("Index");
            }
            else
            {
                return View(cliente);
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var cliente = _clienteService.GetById(id);
            var clienteId = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            if (clienteId == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(clienteId);
            }
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var clienteDelete = _clienteService.GetById(id);
            _clienteService.Remove(clienteDelete);
            return RedirectToAction("Index");
        }
    }
}
