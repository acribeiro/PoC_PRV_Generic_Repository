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

namespace Providencia.MVC.Controllers
{
    public class PRV_GRUPO_TERAPEUTICOController : Controller
    {
        private BancoContexto db = new BancoContexto();

        // GET: PRV_GRUPO_TERAPEUTICO
        public ActionResult Index()
        {
            return View(db.PRV_GRUPO_TERAPEUTICO.ToList());
        }

        // GET: PRV_GRUPO_TERAPEUTICO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_GRUPO_TERAPEUTICO pRV_GRUPO_TERAPEUTICO = db.PRV_GRUPO_TERAPEUTICO.Find(id);
            if (pRV_GRUPO_TERAPEUTICO == null)
            {
                return HttpNotFound();
            }
            return View(pRV_GRUPO_TERAPEUTICO);
        }

        // GET: PRV_GRUPO_TERAPEUTICO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRV_GRUPO_TERAPEUTICO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_GRUPO_TERAPEUTICO,PRV_NOME_GRUPO_TERAPEUTICO,PRV_ENDEREÇO_GRUPO_TERAPEUTICO")] PRV_GRUPO_TERAPEUTICO pRV_GRUPO_TERAPEUTICO)
        {
            if (ModelState.IsValid)
            {
                db.PRV_GRUPO_TERAPEUTICO.Add(pRV_GRUPO_TERAPEUTICO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pRV_GRUPO_TERAPEUTICO);
        }

        // GET: PRV_GRUPO_TERAPEUTICO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_GRUPO_TERAPEUTICO pRV_GRUPO_TERAPEUTICO = db.PRV_GRUPO_TERAPEUTICO.Find(id);
            if (pRV_GRUPO_TERAPEUTICO == null)
            {
                return HttpNotFound();
            }
            return View(pRV_GRUPO_TERAPEUTICO);
        }

        // POST: PRV_GRUPO_TERAPEUTICO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_GRUPO_TERAPEUTICO,PRV_NOME_GRUPO_TERAPEUTICO,PRV_ENDEREÇO_GRUPO_TERAPEUTICO")] PRV_GRUPO_TERAPEUTICO pRV_GRUPO_TERAPEUTICO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRV_GRUPO_TERAPEUTICO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pRV_GRUPO_TERAPEUTICO);
        }

        // GET: PRV_GRUPO_TERAPEUTICO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_GRUPO_TERAPEUTICO pRV_GRUPO_TERAPEUTICO = db.PRV_GRUPO_TERAPEUTICO.Find(id);
            if (pRV_GRUPO_TERAPEUTICO == null)
            {
                return HttpNotFound();
            }
            return View(pRV_GRUPO_TERAPEUTICO);
        }

        // POST: PRV_GRUPO_TERAPEUTICO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRV_GRUPO_TERAPEUTICO pRV_GRUPO_TERAPEUTICO = db.PRV_GRUPO_TERAPEUTICO.Find(id);
            db.PRV_GRUPO_TERAPEUTICO.Remove(pRV_GRUPO_TERAPEUTICO);
            db.SaveChanges();
            return RedirectToAction("Index");
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
