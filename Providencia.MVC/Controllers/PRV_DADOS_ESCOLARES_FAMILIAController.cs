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
    public class PRV_DADOS_ESCOLARES_FAMILIAController : Controller
    {
        private BancoContexto db = new BancoContexto();

        // GET: PRV_DADOS_ESCOLARES_FAMILIA
        public ActionResult Index()
        {
            var pRV_DADOS_ESCOLARES_FAMILIA = db.PRV_DADOS_ESCOLARES_FAMILIA.Include(p => p.PRV_CONSTITUICAO_FAMILIAR).Include(p => p.PRV_ESCOLARIDADE);
            return View(pRV_DADOS_ESCOLARES_FAMILIA.ToList());
        }

        // GET: PRV_DADOS_ESCOLARES_FAMILIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_DADOS_ESCOLARES_FAMILIA pRV_DADOS_ESCOLARES_FAMILIA = db.PRV_DADOS_ESCOLARES_FAMILIA.Find(id);
            if (pRV_DADOS_ESCOLARES_FAMILIA == null)
            {
                return HttpNotFound();
            }
            return View(pRV_DADOS_ESCOLARES_FAMILIA);
        }

        // GET: PRV_DADOS_ESCOLARES_FAMILIA/Create
        public ActionResult Create()
        {
            ViewBag.PRV_ID_MEMBRO_FAMILIA = new SelectList(db.PRV_CONSTITUICAO_FAMILIAR, "PRV_ID_CONSTITUICAO_FAMILIAR", "PRV_NOME_MEMBRO_FAMILIA");
            ViewBag.PRV_ID_ESCOLARIDADE = new SelectList(db.PRV_ESCOLARIDADE, "PRV_ID_ESCOLARIDADE", "PRV_DESCRICAO_ESCOLARIDADE");
            return View();
        }

        // POST: PRV_DADOS_ESCOLARES_FAMILIA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_DADOS_ESCOLARES_FAMILIA,PRV_ID_MEMBRO_FAMILIA,PRV_ID_ESCOLARIDADE")] PRV_DADOS_ESCOLARES_FAMILIA pRV_DADOS_ESCOLARES_FAMILIA)
        {
            if (ModelState.IsValid)
            {
                db.PRV_DADOS_ESCOLARES_FAMILIA.Add(pRV_DADOS_ESCOLARES_FAMILIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRV_ID_MEMBRO_FAMILIA = new SelectList(db.PRV_CONSTITUICAO_FAMILIAR, "PRV_ID_CONSTITUICAO_FAMILIAR", "PRV_NOME_MEMBRO_FAMILIA", pRV_DADOS_ESCOLARES_FAMILIA.PRV_ID_MEMBRO_FAMILIA);
            ViewBag.PRV_ID_ESCOLARIDADE = new SelectList(db.PRV_ESCOLARIDADE, "PRV_ID_ESCOLARIDADE", "PRV_DESCRICAO_ESCOLARIDADE", pRV_DADOS_ESCOLARES_FAMILIA.PRV_ID_ESCOLARIDADE);
            return View(pRV_DADOS_ESCOLARES_FAMILIA);
        }

        // GET: PRV_DADOS_ESCOLARES_FAMILIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_DADOS_ESCOLARES_FAMILIA pRV_DADOS_ESCOLARES_FAMILIA = db.PRV_DADOS_ESCOLARES_FAMILIA.Find(id);
            if (pRV_DADOS_ESCOLARES_FAMILIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRV_ID_MEMBRO_FAMILIA = new SelectList(db.PRV_CONSTITUICAO_FAMILIAR, "PRV_ID_CONSTITUICAO_FAMILIAR", "PRV_NOME_MEMBRO_FAMILIA", pRV_DADOS_ESCOLARES_FAMILIA.PRV_ID_MEMBRO_FAMILIA);
            ViewBag.PRV_ID_ESCOLARIDADE = new SelectList(db.PRV_ESCOLARIDADE, "PRV_ID_ESCOLARIDADE", "PRV_DESCRICAO_ESCOLARIDADE", pRV_DADOS_ESCOLARES_FAMILIA.PRV_ID_ESCOLARIDADE);
            return View(pRV_DADOS_ESCOLARES_FAMILIA);
        }

        // POST: PRV_DADOS_ESCOLARES_FAMILIA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_DADOS_ESCOLARES_FAMILIA,PRV_ID_MEMBRO_FAMILIA,PRV_ID_ESCOLARIDADE")] PRV_DADOS_ESCOLARES_FAMILIA pRV_DADOS_ESCOLARES_FAMILIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRV_DADOS_ESCOLARES_FAMILIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRV_ID_MEMBRO_FAMILIA = new SelectList(db.PRV_CONSTITUICAO_FAMILIAR, "PRV_ID_CONSTITUICAO_FAMILIAR", "PRV_NOME_MEMBRO_FAMILIA", pRV_DADOS_ESCOLARES_FAMILIA.PRV_ID_MEMBRO_FAMILIA);
            ViewBag.PRV_ID_ESCOLARIDADE = new SelectList(db.PRV_ESCOLARIDADE, "PRV_ID_ESCOLARIDADE", "PRV_DESCRICAO_ESCOLARIDADE", pRV_DADOS_ESCOLARES_FAMILIA.PRV_ID_ESCOLARIDADE);
            return View(pRV_DADOS_ESCOLARES_FAMILIA);
        }

        // GET: PRV_DADOS_ESCOLARES_FAMILIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_DADOS_ESCOLARES_FAMILIA pRV_DADOS_ESCOLARES_FAMILIA = db.PRV_DADOS_ESCOLARES_FAMILIA.Find(id);
            if (pRV_DADOS_ESCOLARES_FAMILIA == null)
            {
                return HttpNotFound();
            }
            return View(pRV_DADOS_ESCOLARES_FAMILIA);
        }

        // POST: PRV_DADOS_ESCOLARES_FAMILIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRV_DADOS_ESCOLARES_FAMILIA pRV_DADOS_ESCOLARES_FAMILIA = db.PRV_DADOS_ESCOLARES_FAMILIA.Find(id);
            db.PRV_DADOS_ESCOLARES_FAMILIA.Remove(pRV_DADOS_ESCOLARES_FAMILIA);
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
