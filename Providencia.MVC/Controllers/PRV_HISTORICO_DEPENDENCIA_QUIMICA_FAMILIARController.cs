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
    public class PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIARController : Controller
    {
        private BancoContexto db = new BancoContexto();

        // GET: PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR
        public ActionResult Index()
        {
            var pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR = db.PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR.Include(p => p.PRV_CONSTITUICAO_FAMILIAR);
            return View(pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR.ToList());
        }

        // GET: PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR = db.PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR.Find(id);
            if (pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR == null)
            {
                return HttpNotFound();
            }
            return View(pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR);
        }

        // GET: PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR/Create
        public ActionResult Create()
        {
            ViewBag.PRV_ID_MEMBRO_FAMILIA = new SelectList(db.PRV_CONSTITUICAO_FAMILIAR, "PRV_ID_CONSTITUICAO_FAMILIAR", "PRV_NOME_MEMBRO_FAMILIA");
            return View();
        }

        // POST: PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_HISTORICO_DEPENDENCIA,PRV_EXISTE_HISTORICO_DEPENDENCIA,PRV_ID_MEMBRO_FAMILIA,PRV_FEZ_TRATAMENTO,PRV_LOCAL_TRATAMENTO,PRV_TEMPO_TRATAMENTO,PRV_FAZ_USO_MEDICAMENTO,PRV_NOME_MEDICAMENTO")] PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR)
        {
            if (ModelState.IsValid)
            {
                db.PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR.Add(pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRV_ID_MEMBRO_FAMILIA = new SelectList(db.PRV_CONSTITUICAO_FAMILIAR, "PRV_ID_CONSTITUICAO_FAMILIAR", "PRV_NOME_MEMBRO_FAMILIA", pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR.PRV_ID_MEMBRO_FAMILIA);
            return View(pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR);
        }

        // GET: PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR = db.PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR.Find(id);
            if (pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRV_ID_MEMBRO_FAMILIA = new SelectList(db.PRV_CONSTITUICAO_FAMILIAR, "PRV_ID_CONSTITUICAO_FAMILIAR", "PRV_NOME_MEMBRO_FAMILIA", pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR.PRV_ID_MEMBRO_FAMILIA);
            return View(pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR);
        }

        // POST: PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_HISTORICO_DEPENDENCIA,PRV_EXISTE_HISTORICO_DEPENDENCIA,PRV_ID_MEMBRO_FAMILIA,PRV_FEZ_TRATAMENTO,PRV_LOCAL_TRATAMENTO,PRV_TEMPO_TRATAMENTO,PRV_FAZ_USO_MEDICAMENTO,PRV_NOME_MEDICAMENTO")] PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRV_ID_MEMBRO_FAMILIA = new SelectList(db.PRV_CONSTITUICAO_FAMILIAR, "PRV_ID_CONSTITUICAO_FAMILIAR", "PRV_NOME_MEMBRO_FAMILIA", pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR.PRV_ID_MEMBRO_FAMILIA);
            return View(pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR);
        }

        // GET: PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR = db.PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR.Find(id);
            if (pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR == null)
            {
                return HttpNotFound();
            }
            return View(pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR);
        }

        // POST: PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR = db.PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR.Find(id);
            db.PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR.Remove(pRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR);
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
