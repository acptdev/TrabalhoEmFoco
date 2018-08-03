using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrabalhoEmFoco.Models;

namespace TrabalhoEmFoco.Controllers
{
    public class EmpresaController : Controller
    {
        private TrabalhoEmFocoEntities db = new TrabalhoEmFocoEntities();

        // GET: Empresa
        public ActionResult Index()
        {
            return View(db.EmpCol.ToList());
        }

        // GET: Empresa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpCol empCol = db.EmpCol.Find(id);
            if (empCol == null)
            {
                return HttpNotFound();
            }
            return View(empCol);
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RazaoSocial,CNPJ,Endereco,InscricaoEstadual,Telefone,Email,Responsavel,QtdUsuarios,Usuario,Senha,IdPerfil,Ativo,Tipo")] EmpCol empCol)
        {
            if (ModelState.IsValid)
            {
                empCol.Ativo = true;
                empCol.Tipo = "Empresa";
                db.EmpCol.Add(empCol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empCol);
        }

        // GET: Empresa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpCol empCol = db.EmpCol.Find(id);
            if (empCol == null)
            {
                return HttpNotFound();
            }
            return View(empCol);
        }

        // POST: Empresa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RazaoSocial,CNPJ,Endereco,InscricaoEstadual,Telefone,Email,Responsavel,QtdUsuarios,Usuario,Senha,IdPerfil,Ativo,Tipo")] EmpCol empCol)
        {
            if (ModelState.IsValid)
            {
                empCol.Ativo = true;
                empCol.Tipo = "Empresa";
                db.Entry(empCol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empCol);
        }

        // GET: Empresa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpCol empCol = db.EmpCol.Find(id);
            if (empCol == null)
            {
                return HttpNotFound();
            }
            return View(empCol);
        }

        // POST: Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpCol empCol = db.EmpCol.Find(id);

            empCol.Ativo = false;
            db.Entry(empCol).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

            //db.EmpCol.Remove(empCol);
            //db.SaveChanges();
            //return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
