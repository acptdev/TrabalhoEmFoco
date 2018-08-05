using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoEmFoco.Models;

namespace TrabalhoEmFoco.Controllers
{
	public class HomeController : Controller
	{
        private TrabalhoEmFocoEntities1 db = new TrabalhoEmFocoEntities1();

        //[HttpPost]
        //[ValidateAntiForgeryToken]
		public ActionResult Index()
		{
            //var usr = db.Usuario.Where(x => x.Email == usuario.Email && x.Senha == usuario.Senha).SingleOrDefault();
			return View();
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,Nome,Email,Senha,IdPerfil")] Usuario usuario)
        {
            var usr = db.Usuario.Where(x => x.Email == usuario.Email && x.Senha == usuario.Senha).SingleOrDefault();
            if (usr != null && usr.Id > 0)
            {
                Session["Usuario"] = usr;
                return RedirectToAction("ViewLogada");
            }
            else
            {
                return View();
            }
        }

        public ActionResult AddEmpresa()
        {
            return View();
        }

        public ActionResult ViewLogada()
        {
            return View();
        }

        public ActionResult Sair()
        {
            //Mata a sessão
            Session["Usuario"] = null;
            return RedirectToAction("Index");
        }
	}
}