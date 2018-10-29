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
    public class PRV_BENEFICIOSController : Controller
    {
        //private BancoContexto db = new DAL.Contexto.BancoContexto();
        private readonly BeneficiosRepositorio repBeneficios = new BeneficiosRepositorio();

        // GET: PRV_BENEFICIOS
        public ActionResult Index()
        {
            //return View(db.PRV_BENEFICIOS.ToList());
            return View(repBeneficios.GetAll(b => b.PRV_DESCRICAO_BENEFICIOS).ToList());
        }

        // GET: PRV_BENEFICIOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_BENEFICIOS pRV_BENEFICIOS = db.PRV_BENEFICIOS.Find(id);
            PRV_BENEFICIOS pRV_BENEFICIOS = repBeneficios.Find(id);
            if (pRV_BENEFICIOS == null)
            {
                return HttpNotFound();
            }
            return View(pRV_BENEFICIOS);
        }

        // GET: PRV_BENEFICIOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRV_BENEFICIOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_BENEFICIOS,PRV_DESCRICAO_BENEFICIOS")] PRV_BENEFICIOS pRV_BENEFICIOS)
        {
            if (ModelState.IsValid)
            {
                //db.PRV_BENEFICIOS.Add(pRV_BENEFICIOS);
                repBeneficios.Adicionar(pRV_BENEFICIOS);
                repBeneficios.SalvarTodos();
                return RedirectToAction("Index");
            }

            return View(pRV_BENEFICIOS);
        }

        // GET: PRV_BENEFICIOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_BENEFICIOS pRV_BENEFICIOS = db.PRV_BENEFICIOS.Find(id);
            PRV_BENEFICIOS pRV_BENEFICIOS = repBeneficios.Find(id);
            if (pRV_BENEFICIOS == null)
            {
                return HttpNotFound();
            }
            return View(pRV_BENEFICIOS);
        }

        // POST: PRV_BENEFICIOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_BENEFICIOS,PRV_DESCRICAO_BENEFICIOS")] PRV_BENEFICIOS pRV_BENEFICIOS)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(pRV_BENEFICIOS).State = EntityState.Modified;
                repBeneficios.Atualizar(pRV_BENEFICIOS);
                //db.SaveChanges();
                repBeneficios.SalvarTodos();
                return RedirectToAction("Index");
            }
            return View(pRV_BENEFICIOS);
        }

        // GET: PRV_BENEFICIOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_BENEFICIOS pRV_BENEFICIOS = db.PRV_BENEFICIOS.Find(id);
            PRV_BENEFICIOS pRV_BENEFICIOS = repBeneficios.Find(id);
            if (pRV_BENEFICIOS == null)
            {
                return HttpNotFound();
            }
            return View(pRV_BENEFICIOS);
        }

        // POST: PRV_BENEFICIOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //PRV_BENEFICIOS pRV_BENEFICIOS = db.PRV_BENEFICIOS.Find(id);
            PRV_BENEFICIOS pRV_BENEFICIOS = repBeneficios.Find(id);
            //db.PRV_BENEFICIOS.Remove(pRV_BENEFICIOS);
            repBeneficios.Excluir(b => b == pRV_BENEFICIOS);
            //db.SaveChanges();
            repBeneficios.SalvarTodos();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            repBeneficios.Dispose();
            base.Dispose(disposing);
        }
    }
}
