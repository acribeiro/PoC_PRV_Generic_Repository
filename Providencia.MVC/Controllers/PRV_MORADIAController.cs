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
    public class PRV_MORADIAController : Controller
    {
        private BancoContexto db = new BancoContexto();

        // GET: PRV_MORADIA
        public ActionResult Index()
        {
            var pRV_MORADIA = db.PRV_MORADIA.Include(p => p.PRV_EDUCANDO).Include(p => p.PRV_TIPO_MORADIA);
            return View(pRV_MORADIA.ToList());
        }

        // GET: PRV_MORADIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_MORADIA pRV_MORADIA = db.PRV_MORADIA.Find(id);
            if (pRV_MORADIA == null)
            {
                return HttpNotFound();
            }
            return View(pRV_MORADIA);
        }

        // GET: PRV_MORADIA/Create
        public ActionResult Create()
        {
            ViewBag.PRV_ID_EDUCANDO = new SelectList(db.PRV_EDUCANDO, "PRV_ID_EDUCANDO", "PRV_NOME_RESPONSAVEL");
            ViewBag.PRV_ID_TIPO_MORADIA_RESPONSAVEL = new SelectList(db.PRV_TIPO_MORADIA, "PRV_ID_TIPO_MORADIA", "PRV_DESCRICAO_TIPO_MORADIA");
            return View();
        }

        // POST: PRV_MORADIA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_MORADIA,PRV_ID_EDUCANDO,PRV_ID_TIPO_MORADIA_RESPONSAVEL,PRV_QUANTIDADE_QUARTOS,PRV_QUANTIDADE_SALAS,PRV_QUANTIDADE_BANHEIROS,PRV_QUANTIDADE_COZINHAS,PRV_QUANTIDADE_AREA_DE_SERVICO,PRV_QUANTIDADE_QUINTAL")] PRV_MORADIA pRV_MORADIA)
        {
            if (ModelState.IsValid)
            {
                db.PRV_MORADIA.Add(pRV_MORADIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRV_ID_EDUCANDO = new SelectList(db.PRV_EDUCANDO, "PRV_ID_EDUCANDO", "PRV_NOME_RESPONSAVEL", pRV_MORADIA.PRV_ID_EDUCANDO);
            ViewBag.PRV_ID_TIPO_MORADIA_RESPONSAVEL = new SelectList(db.PRV_TIPO_MORADIA, "PRV_ID_TIPO_MORADIA", "PRV_DESCRICAO_TIPO_MORADIA", pRV_MORADIA.PRV_ID_TIPO_MORADIA_RESPONSAVEL);
            return View(pRV_MORADIA);
        }

        // GET: PRV_MORADIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_MORADIA pRV_MORADIA = db.PRV_MORADIA.Find(id);
            if (pRV_MORADIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRV_ID_EDUCANDO = new SelectList(db.PRV_EDUCANDO, "PRV_ID_EDUCANDO", "PRV_NOME_RESPONSAVEL", pRV_MORADIA.PRV_ID_EDUCANDO);
            ViewBag.PRV_ID_TIPO_MORADIA_RESPONSAVEL = new SelectList(db.PRV_TIPO_MORADIA, "PRV_ID_TIPO_MORADIA", "PRV_DESCRICAO_TIPO_MORADIA", pRV_MORADIA.PRV_ID_TIPO_MORADIA_RESPONSAVEL);
            return View(pRV_MORADIA);
        }

        // POST: PRV_MORADIA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_MORADIA,PRV_ID_EDUCANDO,PRV_ID_TIPO_MORADIA_RESPONSAVEL,PRV_QUANTIDADE_QUARTOS,PRV_QUANTIDADE_SALAS,PRV_QUANTIDADE_BANHEIROS,PRV_QUANTIDADE_COZINHAS,PRV_QUANTIDADE_AREA_DE_SERVICO,PRV_QUANTIDADE_QUINTAL")] PRV_MORADIA pRV_MORADIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRV_MORADIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRV_ID_EDUCANDO = new SelectList(db.PRV_EDUCANDO, "PRV_ID_EDUCANDO", "PRV_NOME_RESPONSAVEL", pRV_MORADIA.PRV_ID_EDUCANDO);
            ViewBag.PRV_ID_TIPO_MORADIA_RESPONSAVEL = new SelectList(db.PRV_TIPO_MORADIA, "PRV_ID_TIPO_MORADIA", "PRV_DESCRICAO_TIPO_MORADIA", pRV_MORADIA.PRV_ID_TIPO_MORADIA_RESPONSAVEL);
            return View(pRV_MORADIA);
        }

        // GET: PRV_MORADIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_MORADIA pRV_MORADIA = db.PRV_MORADIA.Find(id);
            if (pRV_MORADIA == null)
            {
                return HttpNotFound();
            }
            return View(pRV_MORADIA);
        }

        // POST: PRV_MORADIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRV_MORADIA pRV_MORADIA = db.PRV_MORADIA.Find(id);
            db.PRV_MORADIA.Remove(pRV_MORADIA);
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
