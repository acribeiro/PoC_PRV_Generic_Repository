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
    public class PRV_TIPO_MORADIAController : Controller
    {
        //private BancoContexto db = new BancoContexto();
        private readonly TipoMoradiaRepositorio repTipoMoradia = new TipoMoradiaRepositorio();

        // GET: PRV_TIPO_MORADIA
        public ActionResult Index()
        {
            //return View(db.PRV_TIPO_MORADIA.ToList());
            return View(repTipoMoradia.GetAll(tm => tm.PRV_DESCRICAO_TIPO_MORADIA).ToList());
        }

        // GET: PRV_TIPO_MORADIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_TIPO_MORADIA pRV_TIPO_MORADIA = db.PRV_TIPO_MORADIA.Find(id);
            PRV_TIPO_MORADIA pRV_TIPO_MORADIA = repTipoMoradia.Find(id);
            if (pRV_TIPO_MORADIA == null)
            {
                return HttpNotFound();
            }
            return View(pRV_TIPO_MORADIA);
        }

        // GET: PRV_TIPO_MORADIA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRV_TIPO_MORADIA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_TIPO_MORADIA,PRV_DESCRICAO_TIPO_MORADIA")] PRV_TIPO_MORADIA pRV_TIPO_MORADIA)
        {
            if (ModelState.IsValid)
            {
                //db.PRV_TIPO_MORADIA.Add(pRV_TIPO_MORADIA);
                //db.SaveChanges();
                repTipoMoradia.Adicionar(pRV_TIPO_MORADIA);
                repTipoMoradia.SalvarTodos();
                return RedirectToAction("Index");
            }

            return View(pRV_TIPO_MORADIA);
        }

        // GET: PRV_TIPO_MORADIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_TIPO_MORADIA pRV_TIPO_MORADIA = db.PRV_TIPO_MORADIA.Find(id);
            PRV_TIPO_MORADIA pRV_TIPO_MORADIA = repTipoMoradia.Find(id);
            if (pRV_TIPO_MORADIA == null)
            {
                return HttpNotFound();
            }
            return View(pRV_TIPO_MORADIA);
        }

        // POST: PRV_TIPO_MORADIA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_TIPO_MORADIA,PRV_DESCRICAO_TIPO_MORADIA")] PRV_TIPO_MORADIA pRV_TIPO_MORADIA)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(pRV_TIPO_MORADIA).State = EntityState.Modified;
                //db.SaveChanges();
                repTipoMoradia.Atualizar(pRV_TIPO_MORADIA);
                repTipoMoradia.SalvarTodos();
                return RedirectToAction("Index");
            }
            return View(pRV_TIPO_MORADIA);
        }

        // GET: PRV_TIPO_MORADIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_TIPO_MORADIA pRV_TIPO_MORADIA = db.PRV_TIPO_MORADIA.Find(id);
            PRV_TIPO_MORADIA pRV_TIPO_MORADIA = repTipoMoradia.Find(id);
            if (pRV_TIPO_MORADIA == null)
            {
                return HttpNotFound();
            }
            return View(pRV_TIPO_MORADIA);
        }

        // POST: PRV_TIPO_MORADIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //PRV_TIPO_MORADIA pRV_TIPO_MORADIA = db.PRV_TIPO_MORADIA.Find(id);
            //db.PRV_TIPO_MORADIA.Remove(pRV_TIPO_MORADIA);
            //db.SaveChanges();
            PRV_TIPO_MORADIA pRV_TIPO_MORADIA = repTipoMoradia.Find(id);
            repTipoMoradia.Excluir(tm => tm == pRV_TIPO_MORADIA);
            repTipoMoradia.SalvarTodos();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            repTipoMoradia.Dispose();
            base.Dispose(disposing);
        }
    }
}
