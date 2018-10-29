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
    public class PRV_ESTADO_CIVILController : Controller
    {
        //private BancoContexto db = new BancoContexto();
        private readonly EstadoCivilRepositorio repEstadoCivil = new EstadoCivilRepositorio();
        // GET: PRV_ESTADO_CIVIL
        public ActionResult Index()
        {
            return View(repEstadoCivil.GetAll(ec => ec.PRV_DESCRICAO_ESTADO_CIVIL).ToList());
            //return View(db.PRV_ESTADO_CIVIL.ToList());
        }

        // GET: PRV_ESTADO_CIVIL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_ESTADO_CIVIL pRV_ESTADO_CIVIL = db.PRV_ESTADO_CIVIL.Find(id);
            PRV_ESTADO_CIVIL pRV_ESTADO_CIVIL = repEstadoCivil.Find(id);
            if (pRV_ESTADO_CIVIL == null)
            {
                return HttpNotFound();
            }
            return View(pRV_ESTADO_CIVIL);
        }

        // GET: PRV_ESTADO_CIVIL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRV_ESTADO_CIVIL/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_ESTADO_CIVIL,PRV_DESCRICAO_ESTADO_CIVIL")] PRV_ESTADO_CIVIL pRV_ESTADO_CIVIL)
        {
            if (ModelState.IsValid)
            {
                //db.PRV_ESTADO_CIVIL.Add(pRV_ESTADO_CIVIL);
                //db.SaveChanges();
                repEstadoCivil.Adicionar(pRV_ESTADO_CIVIL);
                repEstadoCivil.SalvarTodos();
                return RedirectToAction("Index");
            }

            return View(pRV_ESTADO_CIVIL);
        }

        // GET: PRV_ESTADO_CIVIL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_ESTADO_CIVIL pRV_ESTADO_CIVIL = db.PRV_ESTADO_CIVIL.Find(id);
            PRV_ESTADO_CIVIL pRV_ESTADO_CIVIL = repEstadoCivil.Find(id);
            if (pRV_ESTADO_CIVIL == null)
            {
                return HttpNotFound();
            }
            return View(pRV_ESTADO_CIVIL);
        }

        // POST: PRV_ESTADO_CIVIL/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_ESTADO_CIVIL,PRV_DESCRICAO_ESTADO_CIVIL")] PRV_ESTADO_CIVIL pRV_ESTADO_CIVIL)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(pRV_ESTADO_CIVIL).State = EntityState.Modified;
                //db.SaveChanges();
                repEstadoCivil.Atualizar(pRV_ESTADO_CIVIL);
                repEstadoCivil.SalvarTodos();
                return RedirectToAction("Index");
            }
            return View(pRV_ESTADO_CIVIL);
        }

        // GET: PRV_ESTADO_CIVIL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_ESTADO_CIVIL pRV_ESTADO_CIVIL = db.PRV_ESTADO_CIVIL.Find(id);
            PRV_ESTADO_CIVIL pRV_ESTADO_CIVIL = repEstadoCivil.Find(id);
            if (pRV_ESTADO_CIVIL == null)
            {
                return HttpNotFound();
            }
            return View(pRV_ESTADO_CIVIL);
        }

        // POST: PRV_ESTADO_CIVIL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //PRV_ESTADO_CIVIL pRV_ESTADO_CIVIL = db.PRV_ESTADO_CIVIL.Find(id);
            //db.PRV_ESTADO_CIVIL.Remove(pRV_ESTADO_CIVIL);
            //db.SaveChanges();
            PRV_ESTADO_CIVIL pRV_ESTADO_CIVIL = repEstadoCivil.Find(id);
            repEstadoCivil.Excluir(ec => ec == pRV_ESTADO_CIVIL);
            repEstadoCivil.SalvarTodos();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            repEstadoCivil.Dispose();
            base.Dispose(disposing);
        }
    }
}
