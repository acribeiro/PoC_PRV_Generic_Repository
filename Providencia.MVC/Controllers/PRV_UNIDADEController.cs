using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Providencia.DAL.Contexto;
using Providencia.DAL.Repositorios;
using Providencia.Entidades;

namespace Providencia.MVC.Controllers
{
    public class PRV_UNIDADEController : Controller
    {
        private BancoContexto db = new BancoContexto();
        private readonly UnidadeRepositorio repUnidadeRepositorio = new UnidadeRepositorio();

        // GET: PRV_UNIDADE
        public ActionResult Index()
        {
            var prv_Unidade = repUnidadeRepositorio.GetAll(u => u.PRV_NOME_UNIDADE);
            return View(prv_Unidade.ToList());
        }

        // GET: PRV_UNIDADE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_UNIDADE pRV_UNIDADE = db.PRV_UNIDADE.Find(id);
            if (pRV_UNIDADE == null)
            {
                return HttpNotFound();
            }
            return View(pRV_UNIDADE);
        }

        // GET: PRV_UNIDADE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRV_UNIDADE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_UNIDADE,PRV_NOME_UNIDADE,PRV_CNPJ_UNIDADE,PRV_CEP_UNIDADE,PRV_ENDEREÇO_UNIDADE,PRV_EMAIL_UNIDADE,PRV_TELEFONE_UNIDADE")] PRV_UNIDADE pRV_UNIDADE)
        {
            if (ModelState.IsValid)
            {
                db.PRV_UNIDADE.Add(pRV_UNIDADE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pRV_UNIDADE);
        }

        // GET: PRV_UNIDADE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_UNIDADE pRV_UNIDADE = db.PRV_UNIDADE.Find(id);
            if (pRV_UNIDADE == null)
            {
                return HttpNotFound();
            }
            return View(pRV_UNIDADE);
        }

        // POST: PRV_UNIDADE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_UNIDADE,PRV_NOME_UNIDADE,PRV_CNPJ_UNIDADE,PRV_CEP_UNIDADE,PRV_ENDEREÇO_UNIDADE,PRV_EMAIL_UNIDADE,PRV_TELEFONE_UNIDADE")] PRV_UNIDADE pRV_UNIDADE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRV_UNIDADE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pRV_UNIDADE);
        }

        // GET: PRV_UNIDADE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_UNIDADE pRV_UNIDADE = db.PRV_UNIDADE.Find(id);
            if (pRV_UNIDADE == null)
            {
                return HttpNotFound();
            }
            return View(pRV_UNIDADE);
        }

        // POST: PRV_UNIDADE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRV_UNIDADE pRV_UNIDADE = db.PRV_UNIDADE.Find(id);
            db.PRV_UNIDADE.Remove(pRV_UNIDADE);
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
