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
    public class PRV_MORADORES_RESIDENCIA_EDUCANDOController : Controller
    {
        private BancoContexto db = new BancoContexto();

        // GET: PRV_MORADORES_RESIDENCIA_EDUCANDO
        public ActionResult Index()
        {
            var pRV_MORADORES_RESIDENCIA_EDUCANDO = db.PRV_MORADORES_RESIDENCIA_EDUCANDO.Include(p => p.PRV_CONSTITUICAO_FAMILIAR);
            return View(pRV_MORADORES_RESIDENCIA_EDUCANDO.ToList());
        }

        // GET: PRV_MORADORES_RESIDENCIA_EDUCANDO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_MORADORES_RESIDENCIA_EDUCANDO pRV_MORADORES_RESIDENCIA_EDUCANDO = db.PRV_MORADORES_RESIDENCIA_EDUCANDO.Find(id);
            if (pRV_MORADORES_RESIDENCIA_EDUCANDO == null)
            {
                return HttpNotFound();
            }
            return View(pRV_MORADORES_RESIDENCIA_EDUCANDO);
        }

        // GET: PRV_MORADORES_RESIDENCIA_EDUCANDO/Create
        public ActionResult Create()
        {
            ViewBag.PRV_ID_MEMBRO_FAMILIA = new SelectList(db.PRV_CONSTITUICAO_FAMILIAR, "PRV_ID_CONSTITUICAO_FAMILIAR", "PRV_NOME_MEMBRO_FAMILIA");
            return View();
        }

        // POST: PRV_MORADORES_RESIDENCIA_EDUCANDO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_MORADORES_RESIDENCIA_EDUCANDO,PRV_ID_MEMBRO_FAMILIA,PRV_VACINACAO_EM_DIA,PRV_POSSUI_ACOMPANHAMENTO_MEDICO,PRV_DESCRIACAO_POSSUI_ACOMPANHAMENTO_MEDICO,PRV_PARTICIPA_DO_PROJETO,PRV_DESCRIACAO_PARTICIPA_DO_PROJETO")] PRV_MORADORES_RESIDENCIA_EDUCANDO pRV_MORADORES_RESIDENCIA_EDUCANDO)
        {
            if (ModelState.IsValid)
            {
                db.PRV_MORADORES_RESIDENCIA_EDUCANDO.Add(pRV_MORADORES_RESIDENCIA_EDUCANDO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRV_ID_MEMBRO_FAMILIA = new SelectList(db.PRV_CONSTITUICAO_FAMILIAR, "PRV_ID_CONSTITUICAO_FAMILIAR", "PRV_NOME_MEMBRO_FAMILIA", pRV_MORADORES_RESIDENCIA_EDUCANDO.PRV_ID_MEMBRO_FAMILIA);
            return View(pRV_MORADORES_RESIDENCIA_EDUCANDO);
        }

        // GET: PRV_MORADORES_RESIDENCIA_EDUCANDO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_MORADORES_RESIDENCIA_EDUCANDO pRV_MORADORES_RESIDENCIA_EDUCANDO = db.PRV_MORADORES_RESIDENCIA_EDUCANDO.Find(id);
            if (pRV_MORADORES_RESIDENCIA_EDUCANDO == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRV_ID_MEMBRO_FAMILIA = new SelectList(db.PRV_CONSTITUICAO_FAMILIAR, "PRV_ID_CONSTITUICAO_FAMILIAR", "PRV_NOME_MEMBRO_FAMILIA", pRV_MORADORES_RESIDENCIA_EDUCANDO.PRV_ID_MEMBRO_FAMILIA);
            return View(pRV_MORADORES_RESIDENCIA_EDUCANDO);
        }

        // POST: PRV_MORADORES_RESIDENCIA_EDUCANDO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_MORADORES_RESIDENCIA_EDUCANDO,PRV_ID_MEMBRO_FAMILIA,PRV_VACINACAO_EM_DIA,PRV_POSSUI_ACOMPANHAMENTO_MEDICO,PRV_DESCRIACAO_POSSUI_ACOMPANHAMENTO_MEDICO,PRV_PARTICIPA_DO_PROJETO,PRV_DESCRIACAO_PARTICIPA_DO_PROJETO")] PRV_MORADORES_RESIDENCIA_EDUCANDO pRV_MORADORES_RESIDENCIA_EDUCANDO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRV_MORADORES_RESIDENCIA_EDUCANDO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRV_ID_MEMBRO_FAMILIA = new SelectList(db.PRV_CONSTITUICAO_FAMILIAR, "PRV_ID_CONSTITUICAO_FAMILIAR", "PRV_NOME_MEMBRO_FAMILIA", pRV_MORADORES_RESIDENCIA_EDUCANDO.PRV_ID_MEMBRO_FAMILIA);
            return View(pRV_MORADORES_RESIDENCIA_EDUCANDO);
        }

        // GET: PRV_MORADORES_RESIDENCIA_EDUCANDO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_MORADORES_RESIDENCIA_EDUCANDO pRV_MORADORES_RESIDENCIA_EDUCANDO = db.PRV_MORADORES_RESIDENCIA_EDUCANDO.Find(id);
            if (pRV_MORADORES_RESIDENCIA_EDUCANDO == null)
            {
                return HttpNotFound();
            }
            return View(pRV_MORADORES_RESIDENCIA_EDUCANDO);
        }

        // POST: PRV_MORADORES_RESIDENCIA_EDUCANDO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRV_MORADORES_RESIDENCIA_EDUCANDO pRV_MORADORES_RESIDENCIA_EDUCANDO = db.PRV_MORADORES_RESIDENCIA_EDUCANDO.Find(id);
            db.PRV_MORADORES_RESIDENCIA_EDUCANDO.Remove(pRV_MORADORES_RESIDENCIA_EDUCANDO);
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
