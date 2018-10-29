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
    public class PRV_ESCOLARIDADE_EDUCANDOController : Controller
    {
        private BancoContexto db = new BancoContexto();

        // GET: PRV_ESCOLARIDADE_EDUCANDO
        public ActionResult Index()
        {
            var pRV_ESCOLARIDADE_EDUCANDO = db.PRV_ESCOLARIDADE_EDUCANDO.Include(p => p.PRV_EDUCANDO);
            return View(pRV_ESCOLARIDADE_EDUCANDO.ToList());
        }

        // GET: PRV_ESCOLARIDADE_EDUCANDO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_ESCOLARIDADE_EDUCANDO pRV_ESCOLARIDADE_EDUCANDO = db.PRV_ESCOLARIDADE_EDUCANDO.Find(id);
            if (pRV_ESCOLARIDADE_EDUCANDO == null)
            {
                return HttpNotFound();
            }
            return View(pRV_ESCOLARIDADE_EDUCANDO);
        }

        // GET: PRV_ESCOLARIDADE_EDUCANDO/Create
        public ActionResult Create()
        {
            ViewBag.PRV_ID_EDUCANDO = new SelectList(db.PRV_EDUCANDO, "PRV_ID_EDUCANDO", "PRV_NOME_RESPONSAVEL");
            return View();
        }

        // POST: PRV_ESCOLARIDADE_EDUCANDO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_DADOS_ESCOLARIDADE_EDUCANDO,PRV_ID_EDUCANDO,PRV_SERIE_ESCOLARIDADE_EDUCANDO,PRV_ENSINO,PRV_TURNO,PRV_REPETINDO_SERIE_ATUAL")] PRV_ESCOLARIDADE_EDUCANDO pRV_ESCOLARIDADE_EDUCANDO)
        {
            if (ModelState.IsValid)
            {
                db.PRV_ESCOLARIDADE_EDUCANDO.Add(pRV_ESCOLARIDADE_EDUCANDO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRV_ID_EDUCANDO = new SelectList(db.PRV_EDUCANDO, "PRV_ID_EDUCANDO", "PRV_NOME_RESPONSAVEL", pRV_ESCOLARIDADE_EDUCANDO.PRV_ID_EDUCANDO);
            return View(pRV_ESCOLARIDADE_EDUCANDO);
        }

        // GET: PRV_ESCOLARIDADE_EDUCANDO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_ESCOLARIDADE_EDUCANDO pRV_ESCOLARIDADE_EDUCANDO = db.PRV_ESCOLARIDADE_EDUCANDO.Find(id);
            if (pRV_ESCOLARIDADE_EDUCANDO == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRV_ID_EDUCANDO = new SelectList(db.PRV_EDUCANDO, "PRV_ID_EDUCANDO", "PRV_NOME_RESPONSAVEL", pRV_ESCOLARIDADE_EDUCANDO.PRV_ID_EDUCANDO);
            return View(pRV_ESCOLARIDADE_EDUCANDO);
        }

        // POST: PRV_ESCOLARIDADE_EDUCANDO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_DADOS_ESCOLARIDADE_EDUCANDO,PRV_ID_EDUCANDO,PRV_SERIE_ESCOLARIDADE_EDUCANDO,PRV_ENSINO,PRV_TURNO,PRV_REPETINDO_SERIE_ATUAL")] PRV_ESCOLARIDADE_EDUCANDO pRV_ESCOLARIDADE_EDUCANDO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRV_ESCOLARIDADE_EDUCANDO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRV_ID_EDUCANDO = new SelectList(db.PRV_EDUCANDO, "PRV_ID_EDUCANDO", "PRV_NOME_RESPONSAVEL", pRV_ESCOLARIDADE_EDUCANDO.PRV_ID_EDUCANDO);
            return View(pRV_ESCOLARIDADE_EDUCANDO);
        }

        // GET: PRV_ESCOLARIDADE_EDUCANDO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_ESCOLARIDADE_EDUCANDO pRV_ESCOLARIDADE_EDUCANDO = db.PRV_ESCOLARIDADE_EDUCANDO.Find(id);
            if (pRV_ESCOLARIDADE_EDUCANDO == null)
            {
                return HttpNotFound();
            }
            return View(pRV_ESCOLARIDADE_EDUCANDO);
        }

        // POST: PRV_ESCOLARIDADE_EDUCANDO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRV_ESCOLARIDADE_EDUCANDO pRV_ESCOLARIDADE_EDUCANDO = db.PRV_ESCOLARIDADE_EDUCANDO.Find(id);
            db.PRV_ESCOLARIDADE_EDUCANDO.Remove(pRV_ESCOLARIDADE_EDUCANDO);
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
