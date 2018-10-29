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
    public class PRV_VIOLENCIA_NA_FAMILIAController : Controller
    {
        private BancoContexto db = new BancoContexto();

        // GET: PRV_VIOLENCIA_NA_FAMILIA
        public ActionResult Index()
        {
            var pRV_VIOLENCIA_NA_FAMILIA = db.PRV_VIOLENCIA_NA_FAMILIA.Include(p => p.PRV_CONSTITUICAO_FAMILIAR);
            return View(pRV_VIOLENCIA_NA_FAMILIA.ToList());
        }

        // GET: PRV_VIOLENCIA_NA_FAMILIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_VIOLENCIA_NA_FAMILIA pRV_VIOLENCIA_NA_FAMILIA = db.PRV_VIOLENCIA_NA_FAMILIA.Find(id);
            if (pRV_VIOLENCIA_NA_FAMILIA == null)
            {
                return HttpNotFound();
            }
            return View(pRV_VIOLENCIA_NA_FAMILIA);
        }

        // GET: PRV_VIOLENCIA_NA_FAMILIA/Create
        public ActionResult Create()
        {
            ViewBag.PRV_ID_MEMBRO_FAMILIA_SOFREU_VIOLENCIA = new SelectList(db.PRV_CONSTITUICAO_FAMILIAR, "PRV_ID_CONSTITUICAO_FAMILIAR", "PRV_NOME_MEMBRO_FAMILIA");
            return View();
        }

        // POST: PRV_VIOLENCIA_NA_FAMILIA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_VIOLENCIA_NA_FAMILIA,PRV_SOFREU_VIOLENCIA,PRV_ID_MEMBRO_FAMILIA_SOFREU_VIOLENCIA,PRV_MEDIDAS_TOMADAS,PRV_ACIONOU_AUTORIDADES")] PRV_VIOLENCIA_NA_FAMILIA pRV_VIOLENCIA_NA_FAMILIA)
        {
            if (ModelState.IsValid)
            {
                db.PRV_VIOLENCIA_NA_FAMILIA.Add(pRV_VIOLENCIA_NA_FAMILIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRV_ID_MEMBRO_FAMILIA_SOFREU_VIOLENCIA = new SelectList(db.PRV_CONSTITUICAO_FAMILIAR, "PRV_ID_CONSTITUICAO_FAMILIAR", "PRV_NOME_MEMBRO_FAMILIA", pRV_VIOLENCIA_NA_FAMILIA.PRV_ID_MEMBRO_FAMILIA_SOFREU_VIOLENCIA);
            return View(pRV_VIOLENCIA_NA_FAMILIA);
        }

        // GET: PRV_VIOLENCIA_NA_FAMILIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_VIOLENCIA_NA_FAMILIA pRV_VIOLENCIA_NA_FAMILIA = db.PRV_VIOLENCIA_NA_FAMILIA.Find(id);
            if (pRV_VIOLENCIA_NA_FAMILIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRV_ID_MEMBRO_FAMILIA_SOFREU_VIOLENCIA = new SelectList(db.PRV_CONSTITUICAO_FAMILIAR, "PRV_ID_CONSTITUICAO_FAMILIAR", "PRV_NOME_MEMBRO_FAMILIA", pRV_VIOLENCIA_NA_FAMILIA.PRV_ID_MEMBRO_FAMILIA_SOFREU_VIOLENCIA);
            return View(pRV_VIOLENCIA_NA_FAMILIA);
        }

        // POST: PRV_VIOLENCIA_NA_FAMILIA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_VIOLENCIA_NA_FAMILIA,PRV_SOFREU_VIOLENCIA,PRV_ID_MEMBRO_FAMILIA_SOFREU_VIOLENCIA,PRV_MEDIDAS_TOMADAS,PRV_ACIONOU_AUTORIDADES")] PRV_VIOLENCIA_NA_FAMILIA pRV_VIOLENCIA_NA_FAMILIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRV_VIOLENCIA_NA_FAMILIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRV_ID_MEMBRO_FAMILIA_SOFREU_VIOLENCIA = new SelectList(db.PRV_CONSTITUICAO_FAMILIAR, "PRV_ID_CONSTITUICAO_FAMILIAR", "PRV_NOME_MEMBRO_FAMILIA", pRV_VIOLENCIA_NA_FAMILIA.PRV_ID_MEMBRO_FAMILIA_SOFREU_VIOLENCIA);
            return View(pRV_VIOLENCIA_NA_FAMILIA);
        }

        // GET: PRV_VIOLENCIA_NA_FAMILIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_VIOLENCIA_NA_FAMILIA pRV_VIOLENCIA_NA_FAMILIA = db.PRV_VIOLENCIA_NA_FAMILIA.Find(id);
            if (pRV_VIOLENCIA_NA_FAMILIA == null)
            {
                return HttpNotFound();
            }
            return View(pRV_VIOLENCIA_NA_FAMILIA);
        }

        // POST: PRV_VIOLENCIA_NA_FAMILIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRV_VIOLENCIA_NA_FAMILIA pRV_VIOLENCIA_NA_FAMILIA = db.PRV_VIOLENCIA_NA_FAMILIA.Find(id);
            db.PRV_VIOLENCIA_NA_FAMILIA.Remove(pRV_VIOLENCIA_NA_FAMILIA);
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
