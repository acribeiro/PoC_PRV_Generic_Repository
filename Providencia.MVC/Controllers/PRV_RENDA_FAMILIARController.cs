using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Providencia.DAL.Contexto;
using Providencia.Entidades;
using Providencia.DAL.Repositorios;

namespace Providencia.MVC.Controllers
{
    public class PRV_RENDA_FAMILIARController : Controller
    {
        //private BancoContexto db = new BancoContexto();
        private readonly RendaFamiliarRepositorio repRendaFamiliar = new RendaFamiliarRepositorio();

        // GET: PRV_RENDA_FAMILIAR
        public ActionResult Index()
        {
            //return View(db.PRV_RENDA_FAMILIAR.ToList());
            return View(repRendaFamiliar.GetAll(rf => rf.PRV_DESCRICAO_RENDA_FAMILIAR).ToList());
        }

        // GET: PRV_RENDA_FAMILIAR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_RENDA_FAMILIAR pRV_RENDA_FAMILIAR = db.PRV_RENDA_FAMILIAR.Find(id);
            PRV_RENDA_FAMILIAR pRV_RENDA_FAMILIAR = repRendaFamiliar.Find(id);
            if (pRV_RENDA_FAMILIAR == null)
            {
                return HttpNotFound();
            }
            return View(pRV_RENDA_FAMILIAR);
        }

        // GET: PRV_RENDA_FAMILIAR/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRV_RENDA_FAMILIAR/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_RENDA_FAMILIAR,PRV_DESCRICAO_RENDA_FAMILIAR")] PRV_RENDA_FAMILIAR pRV_RENDA_FAMILIAR)
        {
            if (ModelState.IsValid)
            {
                //db.PRV_RENDA_FAMILIAR.Add(pRV_RENDA_FAMILIAR);
                //db.SaveChanges();
                repRendaFamiliar.Adicionar(pRV_RENDA_FAMILIAR);
                repRendaFamiliar.SalvarTodos();
                return RedirectToAction("Index");
            }

            return View(pRV_RENDA_FAMILIAR);
        }

        // GET: PRV_RENDA_FAMILIAR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_RENDA_FAMILIAR pRV_RENDA_FAMILIAR = db.PRV_RENDA_FAMILIAR.Find(id);
            PRV_RENDA_FAMILIAR pRV_RENDA_FAMILIAR = repRendaFamiliar.Find(id);
            if (pRV_RENDA_FAMILIAR == null)
            {
                return HttpNotFound();
            }
            return View(pRV_RENDA_FAMILIAR);
        }

        // POST: PRV_RENDA_FAMILIAR/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_RENDA_FAMILIAR,PRV_DESCRICAO_RENDA_FAMILIAR")] PRV_RENDA_FAMILIAR pRV_RENDA_FAMILIAR)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(pRV_RENDA_FAMILIAR).State = EntityState.Modified;
                //db.SaveChanges();
                repRendaFamiliar.Atualizar(pRV_RENDA_FAMILIAR);
                repRendaFamiliar.SalvarTodos();
                return RedirectToAction("Index");
            }
            return View(pRV_RENDA_FAMILIAR);
        }

        // GET: PRV_RENDA_FAMILIAR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_RENDA_FAMILIAR pRV_RENDA_FAMILIAR = db.PRV_RENDA_FAMILIAR.Find(id);
            PRV_RENDA_FAMILIAR pRV_RENDA_FAMILIAR = repRendaFamiliar.Find(id);
            if (pRV_RENDA_FAMILIAR == null)
            {
                return HttpNotFound();
            }
            return View(pRV_RENDA_FAMILIAR);
        }

        // POST: PRV_RENDA_FAMILIAR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //PRV_RENDA_FAMILIAR pRV_RENDA_FAMILIAR = db.PRV_RENDA_FAMILIAR.Find(id);
            //db.PRV_RENDA_FAMILIAR.Remove(pRV_RENDA_FAMILIAR);
            //db.SaveChanges();
            PRV_RENDA_FAMILIAR pRV_RENDA_FAMILIAR = repRendaFamiliar.Find(id);
            repRendaFamiliar.Excluir(rf => rf == pRV_RENDA_FAMILIAR);
            repRendaFamiliar.SalvarTodos();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            repRendaFamiliar.Dispose();
            base.Dispose(disposing);
        }
    }
}
