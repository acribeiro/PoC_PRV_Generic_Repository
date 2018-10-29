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
    public class PRV_TIPO_DE_FAMILIAController : Controller
    {
        private BancoContexto db = new BancoContexto();

        // GET: PRV_TIPO_DE_FAMILIA
        public ActionResult Index()
        {
            return View(db.PRV_TIPO_DE_FAMILIA.ToList());
        }

        // GET: PRV_TIPO_DE_FAMILIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_TIPO_DE_FAMILIA pRV_TIPO_DE_FAMILIA = db.PRV_TIPO_DE_FAMILIA.Find(id);
            if (pRV_TIPO_DE_FAMILIA == null)
            {
                return HttpNotFound();
            }
            return View(pRV_TIPO_DE_FAMILIA);
        }

        // GET: PRV_TIPO_DE_FAMILIA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRV_TIPO_DE_FAMILIA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_TIPO_DE_FAMILIA,PRV_DESCRICAO_TIPO_DE_FAMILIA")] PRV_TIPO_DE_FAMILIA pRV_TIPO_DE_FAMILIA)
        {
            if (ModelState.IsValid)
            {
                db.PRV_TIPO_DE_FAMILIA.Add(pRV_TIPO_DE_FAMILIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pRV_TIPO_DE_FAMILIA);
        }

        // GET: PRV_TIPO_DE_FAMILIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_TIPO_DE_FAMILIA pRV_TIPO_DE_FAMILIA = db.PRV_TIPO_DE_FAMILIA.Find(id);
            if (pRV_TIPO_DE_FAMILIA == null)
            {
                return HttpNotFound();
            }
            return View(pRV_TIPO_DE_FAMILIA);
        }

        // POST: PRV_TIPO_DE_FAMILIA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_TIPO_DE_FAMILIA,PRV_DESCRICAO_TIPO_DE_FAMILIA")] PRV_TIPO_DE_FAMILIA pRV_TIPO_DE_FAMILIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRV_TIPO_DE_FAMILIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pRV_TIPO_DE_FAMILIA);
        }

        // GET: PRV_TIPO_DE_FAMILIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_TIPO_DE_FAMILIA pRV_TIPO_DE_FAMILIA = db.PRV_TIPO_DE_FAMILIA.Find(id);
            if (pRV_TIPO_DE_FAMILIA == null)
            {
                return HttpNotFound();
            }
            return View(pRV_TIPO_DE_FAMILIA);
        }

        // POST: PRV_TIPO_DE_FAMILIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRV_TIPO_DE_FAMILIA pRV_TIPO_DE_FAMILIA = db.PRV_TIPO_DE_FAMILIA.Find(id);
            db.PRV_TIPO_DE_FAMILIA.Remove(pRV_TIPO_DE_FAMILIA);
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
