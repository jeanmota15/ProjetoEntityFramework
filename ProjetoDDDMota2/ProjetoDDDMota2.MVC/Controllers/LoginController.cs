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
using System.Web.Security;

namespace ProjetoDDDMota2.MVC.Controllers
{
    public class LoginController : Controller
    {
        private ILoginAppService _loginService;

        public LoginController(ILoginAppService loginService)
        {
            _loginService = loginService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string usuario, string senha)
        {
            var login = _loginService.Logar(usuario, senha);
            var loginId = Mapper.Map<Login, LoginViewModel>(login);

            if (loginId != null)
            {
                Session["Usuario"] = loginId;
                FormsAuthentication.SetAuthCookie(usuario, false);
                return RedirectToAction("Index", "Produto");
            }
            ViewBag.Mensagem = "Login e/ou Usuário Inválidos!";
            return View();
        }


        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
