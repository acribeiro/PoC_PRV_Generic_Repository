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
    public class PRV_ESCOLARIDADEController : Controller
    {
        ///private BancoContexto db = new BancoContexto();
        private readonly EscolaridadeRepositorio repEscolaridade = new EscolaridadeRepositorio();

        // GET: PRV_ESCOLARIDADE
        public ActionResult Index()
        {
            //return View(db.PRV_ESCOLARIDADE.ToList());
            return View(repEscolaridade.GetAll().ToList());
        }

        // GET: PRV_ESCOLARIDADE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_ESCOLARIDADE pRV_ESCOLARIDADE = db.PRV_ESCOLARIDADE.Find(id);
            PRV_ESCOLARIDADE pRV_ESCOLARIDADE = repEscolaridade.Find(id);
            if (pRV_ESCOLARIDADE == null)
            {
                return HttpNotFound();
            }
            return View(pRV_ESCOLARIDADE);
        }

        // GET: PRV_ESCOLARIDADE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRV_ESCOLARIDADE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_ESCOLARIDADE,PRV_DESCRICAO_ESCOLARIDADE")] PRV_ESCOLARIDADE pRV_ESCOLARIDADE)
        {
            if (ModelState.IsValid)
            {
                //db.PRV_ESCOLARIDADE.Add(pRV_ESCOLARIDADE);
                //db.SaveChanges();
                repEscolaridade.Adicionar(pRV_ESCOLARIDADE);
                repEscolaridade.SalvarTodos();
                return RedirectToAction("Index");
            }

            return View(pRV_ESCOLARIDADE);
        }

        // GET: PRV_ESCOLARIDADE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_ESCOLARIDADE pRV_ESCOLARIDADE = db.PRV_ESCOLARIDADE.Find(id);
            PRV_ESCOLARIDADE pRV_ESCOLARIDADE = repEscolaridade.Find(id);
            if (pRV_ESCOLARIDADE == null)
            {
                return HttpNotFound();
            }
            return View(pRV_ESCOLARIDADE);
        }

        // POST: PRV_ESCOLARIDADE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_ESCOLARIDADE,PRV_DESCRICAO_ESCOLARIDADE")] PRV_ESCOLARIDADE pRV_ESCOLARIDADE)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(pRV_ESCOLARIDADE).State = EntityState.Modified;
                //db.SaveChanges();
                repEscolaridade.Atualizar(pRV_ESCOLARIDADE);
                repEscolaridade.SalvarTodos();
                return RedirectToAction("Index");
            }
            return View(pRV_ESCOLARIDADE);
        }

        // GET: PRV_ESCOLARIDADE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_ESCOLARIDADE pRV_ESCOLARIDADE = db.PRV_ESCOLARIDADE.Find(id);
            PRV_ESCOLARIDADE pRV_ESCOLARIDADE = repEscolaridade.Find(id);
            if (pRV_ESCOLARIDADE == null)
            {
                return HttpNotFound();
            }
            return View(pRV_ESCOLARIDADE);
        }

        // POST: PRV_ESCOLARIDADE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //PRV_ESCOLARIDADE pRV_ESCOLARIDADE = db.PRV_ESCOLARIDADE.Find(id);
            //db.PRV_ESCOLARIDADE.Remove(pRV_ESCOLARIDADE);
            //db.SaveChanges();
            PRV_ESCOLARIDADE pRV_ESCOLARIDADE = repEscolaridade.Find(id);
            repEscolaridade.Excluir(e => e == pRV_ESCOLARIDADE);
            repEscolaridade.SalvarTodos();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            repEscolaridade.Dispose();
            base.Dispose(disposing);
        }
    }
}
