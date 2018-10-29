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
    public class PRV_CONSTITUICAO_FAMILIARController : Controller
    {
        private BancoContexto db = new BancoContexto();
        private readonly ConstituicaoFamiliarRepositorio repConstituicaoFamiliar = new ConstituicaoFamiliarRepositorio();

        // GET: PRV_CONSTITUICAO_FAMILIAR
        public ActionResult Index()
        {
            var pRV_CONSTITUICAO_FAMILIAR = db.PRV_CONSTITUICAO_FAMILIAR.Include(p => p.PRV_EDUCANDO);
            //var pRV_CONSTITUICAO_FAMILIAR = repConstituicaoFamiliar.Retorna();
            return View(pRV_CONSTITUICAO_FAMILIAR.ToList());
            //return View(repConstituicaoFamiliar.GetAll(cf => cf.PRV_NOME_MEMBRO_FAMILIA).ToList());
        }

        // GET: PRV_CONSTITUICAO_FAMILIAR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_CONSTITUICAO_FAMILIAR pRV_CONSTITUICAO_FAMILIAR = db.PRV_CONSTITUICAO_FAMILIAR.Find(id);
            if (pRV_CONSTITUICAO_FAMILIAR == null)
            {
                return HttpNotFound();
            }
            return View(pRV_CONSTITUICAO_FAMILIAR);
        }

        // GET: PRV_CONSTITUICAO_FAMILIAR/Create
        public ActionResult Create()
        {
            ViewBag.PRV_ID_EDUCANDO = new SelectList(db.PRV_EDUCANDO, "PRV_ID_EDUCANDO", "PRV_NOME_RESPONSAVEL");
            return View();
        }

        // POST: PRV_CONSTITUICAO_FAMILIAR/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_CONSTITUICAO_FAMILIAR,PRV_NOME_MEMBRO_FAMILIA,PRV_PARENTESCO,PRV_PROFISSAO,PRV_ID_EDUCANDO")] PRV_CONSTITUICAO_FAMILIAR pRV_CONSTITUICAO_FAMILIAR)
        {
            if (ModelState.IsValid)
            {
                db.PRV_CONSTITUICAO_FAMILIAR.Add(pRV_CONSTITUICAO_FAMILIAR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRV_ID_EDUCANDO = new SelectList(db.PRV_EDUCANDO, "PRV_ID_EDUCANDO", "PRV_NOME_RESPONSAVEL", pRV_CONSTITUICAO_FAMILIAR.PRV_ID_EDUCANDO);
            return View(pRV_CONSTITUICAO_FAMILIAR);
        }

        // GET: PRV_CONSTITUICAO_FAMILIAR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_CONSTITUICAO_FAMILIAR pRV_CONSTITUICAO_FAMILIAR = db.PRV_CONSTITUICAO_FAMILIAR.Find(id);
            if (pRV_CONSTITUICAO_FAMILIAR == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRV_ID_EDUCANDO = new SelectList(db.PRV_EDUCANDO, "PRV_ID_EDUCANDO", "PRV_NOME_RESPONSAVEL", pRV_CONSTITUICAO_FAMILIAR.PRV_ID_EDUCANDO);
            return View(pRV_CONSTITUICAO_FAMILIAR);
        }

        // POST: PRV_CONSTITUICAO_FAMILIAR/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_CONSTITUICAO_FAMILIAR,PRV_NOME_MEMBRO_FAMILIA,PRV_PARENTESCO,PRV_PROFISSAO,PRV_ID_EDUCANDO")] PRV_CONSTITUICAO_FAMILIAR pRV_CONSTITUICAO_FAMILIAR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRV_CONSTITUICAO_FAMILIAR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRV_ID_EDUCANDO = new SelectList(db.PRV_EDUCANDO, "PRV_ID_EDUCANDO", "PRV_NOME_RESPONSAVEL", pRV_CONSTITUICAO_FAMILIAR.PRV_ID_EDUCANDO);
            return View(pRV_CONSTITUICAO_FAMILIAR);
        }

        // GET: PRV_CONSTITUICAO_FAMILIAR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_CONSTITUICAO_FAMILIAR pRV_CONSTITUICAO_FAMILIAR = db.PRV_CONSTITUICAO_FAMILIAR.Find(id);
            if (pRV_CONSTITUICAO_FAMILIAR == null)
            {
                return HttpNotFound();
            }
            return View(pRV_CONSTITUICAO_FAMILIAR);
        }

        // POST: PRV_CONSTITUICAO_FAMILIAR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRV_CONSTITUICAO_FAMILIAR pRV_CONSTITUICAO_FAMILIAR = db.PRV_CONSTITUICAO_FAMILIAR.Find(id);
            db.PRV_CONSTITUICAO_FAMILIAR.Remove(pRV_CONSTITUICAO_FAMILIAR);
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
