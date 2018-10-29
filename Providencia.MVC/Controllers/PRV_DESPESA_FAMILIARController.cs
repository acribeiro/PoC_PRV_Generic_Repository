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
    public class PRV_DESPESA_FAMILIARController : Controller
    {
        private BancoContexto db = new BancoContexto();
        private readonly DespesasFamiliarRepositorio repDespesas = new DespesasFamiliarRepositorio();

        // GET: PRV_DESPESA_FAMILIAR
        public ActionResult Index()
        {
            return View(repDespesas.GetAll(df => df.PRV_DESCRICAO_DESPESA_FAMILIAR).ToList());
            //return View(db.PRV_DESPESA_FAMILIAR.ToList());
        }

        // GET: PRV_DESPESA_FAMILIAR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_DESPESA_FAMILIAR pRV_DESPESA_FAMILIAR = db.PRV_DESPESA_FAMILIAR.Find(id);
            PRV_DESPESA_FAMILIAR pRV_DESPESA_FAMILIAR = repDespesas.Find(id);
            if (pRV_DESPESA_FAMILIAR == null)
            {
                return HttpNotFound();
            }
            return View(pRV_DESPESA_FAMILIAR);
        }

        // GET: PRV_DESPESA_FAMILIAR/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRV_DESPESA_FAMILIAR/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_DESPESA_FAMILIAR,PRV_DESCRICAO_DESPESA_FAMILIAR")] PRV_DESPESA_FAMILIAR pRV_DESPESA_FAMILIAR)
        {
            if (ModelState.IsValid)
            {
                //db.PRV_DESPESA_FAMILIAR.Add(pRV_DESPESA_FAMILIAR);
                repDespesas.Adicionar(pRV_DESPESA_FAMILIAR);
                //db.SaveChanges();
                repDespesas.SalvarTodos();
                return RedirectToAction("Index");
            }

            return View(pRV_DESPESA_FAMILIAR);
        }

        // GET: PRV_DESPESA_FAMILIAR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_DESPESA_FAMILIAR pRV_DESPESA_FAMILIAR = db.PRV_DESPESA_FAMILIAR.Find(id);
            PRV_DESPESA_FAMILIAR pRV_DESPESA_FAMILIAR = repDespesas.Find(id);
            if (pRV_DESPESA_FAMILIAR == null)
            {
                return HttpNotFound();
            }
            return View(pRV_DESPESA_FAMILIAR);
        }

        // POST: PRV_DESPESA_FAMILIAR/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_DESPESA_FAMILIAR,PRV_DESCRICAO_DESPESA_FAMILIAR")] PRV_DESPESA_FAMILIAR pRV_DESPESA_FAMILIAR)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(pRV_DESPESA_FAMILIAR).State = EntityState.Modified;
                repDespesas.Atualizar(pRV_DESPESA_FAMILIAR);
                //db.SaveChanges();
                repDespesas.SalvarTodos();
                return RedirectToAction("Index");
            }
            return View(pRV_DESPESA_FAMILIAR);
        }

        // GET: PRV_DESPESA_FAMILIAR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_DESPESA_FAMILIAR pRV_DESPESA_FAMILIAR = db.PRV_DESPESA_FAMILIAR.Find(id);
            PRV_DESPESA_FAMILIAR pRV_DESPESA_FAMILIAR = repDespesas.Find(id);
            if (pRV_DESPESA_FAMILIAR == null)
            {
                return HttpNotFound();
            }
            return View(pRV_DESPESA_FAMILIAR);
        }

        // POST: PRV_DESPESA_FAMILIAR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //PRV_DESPESA_FAMILIAR pRV_DESPESA_FAMILIAR = db.PRV_DESPESA_FAMILIAR.Find(id);
            //db.PRV_DESPESA_FAMILIAR.Remove(pRV_DESPESA_FAMILIAR);
            //db.SaveChanges();
            PRV_DESPESA_FAMILIAR pRV_DESPESA_FAMILIAR = repDespesas.Find(id);
            repDespesas.Excluir(df => df == pRV_DESPESA_FAMILIAR);
            repDespesas.SalvarTodos();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            repDespesas.Dispose();
            base.Dispose(disposing);
        }
    }
}
