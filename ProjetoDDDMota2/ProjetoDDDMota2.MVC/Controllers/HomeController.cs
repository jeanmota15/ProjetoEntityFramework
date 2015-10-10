using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ProjetoDDDMota2.Domain.Entities;
using ProjetoDDDMota2.Application.Interfaces.Services;
using ProjetoDDDMota2.MVC.AutoMapper;
using ProjetoDDDMota2.MVC.ViewModels;

namespace ProjetoDDDMota2.MVC.Controllers
{
    public class HomeController : Controller
    {
        private IClienteAppService _clienteService;

        public HomeController(IClienteAppService clienteService)
        {
            _clienteService = clienteService;
        }

        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        public ActionResult About()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //ViewBag.Message = "Your application description page.";
            var cliente = _clienteService.GetAll();
            var clienteLista = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(cliente);

            var model = from c in clienteLista
                        group c by c.DataCadastro into grupo//pega a dataCadastro e mostra na data
                        select new ClienteViewModel()
                        {
                            Data = grupo.Key,
                            Total = grupo.Count()
                        };

            return View(model);
        }

        public ActionResult Contact()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}