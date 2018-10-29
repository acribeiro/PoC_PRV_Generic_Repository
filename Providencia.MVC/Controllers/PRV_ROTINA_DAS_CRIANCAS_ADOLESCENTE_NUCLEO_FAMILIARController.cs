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
    public class PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIARController : Controller
    {
        private BancoContexto db = new BancoContexto();

        // GET: PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR
        public ActionResult Index()
        {
            var pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR = db.PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR.Include(p => p.PRV_EDUCANDO);
            return View(pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR.ToList());
        }

        // GET: PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR = db.PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR.Find(id);
            if (pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR == null)
            {
                return HttpNotFound();
            }
            return View(pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR);
        }

        // GET: PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR/Create
        public ActionResult Create()
        {
            ViewBag.FK_ID_EDUCANDO_ROTINA = new SelectList(db.PRV_EDUCANDO, "PRV_ID_EDUCANDO", "PRV_NOME_EDUCANDO");
            return View();
        }

        // POST: PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR,DESCRICAO_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR,FK_ID_EDUCANDO_ROTINA")] PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR)
        {
            if (ModelState.IsValid)
            {
                db.PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR.Add(pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_ID_EDUCANDO_ROTINA = new SelectList(db.PRV_EDUCANDO, "PRV_ID_EDUCANDO", "PRV_NOME_EDUCANDO", pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR.FK_ID_EDUCANDO_ROTINA);
            return View(pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR);
        }

        // GET: PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR = db.PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR.Find(id);
            if (pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ID_EDUCANDO_ROTINA = new SelectList(db.PRV_EDUCANDO, "PRV_ID_EDUCANDO", "PRV_NOME_EDUCANDO", pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR.FK_ID_EDUCANDO_ROTINA);
            return View(pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR);
        }

        // POST: PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR,DESCRICAO_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR,FK_ID_EDUCANDO_ROTINA")] PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ID_EDUCANDO_ROTINA = new SelectList(db.PRV_EDUCANDO, "PRV_ID_EDUCANDO", "PRV_NOME_EDUCANDO", pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR.FK_ID_EDUCANDO_ROTINA);
            return View(pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR);
        }

        // GET: PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR = db.PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR.Find(id);
            if (pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR == null)
            {
                return HttpNotFound();
            }
            return View(pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR);
        }

        // POST: PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR = db.PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR.Find(id);
            db.PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR.Remove(pRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR);
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
