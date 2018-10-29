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
    public class PRV_GRUPOController : Controller
    {
        //private BancoContexto db = new BancoContexto();
        private readonly GrupoRepositorio repGrupo = new GrupoRepositorio();

        // GET: PRV_GRUPO
        public ActionResult Index()
        {
            //return View(db.PRV_GRUPO.ToList());
            return View(repGrupo.GetAll(g => g.PRV_NOME_GRUPO).ToList());
        }

        // GET: PRV_GRUPO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_GRUPO pRV_GRUPO = db.PRV_GRUPO.Find(id);
            PRV_GRUPO pRV_GRUPO = repGrupo.Find(id);
            if (pRV_GRUPO == null)
            {
                return HttpNotFound();
            }
            return View(pRV_GRUPO);
        }

        // GET: PRV_GRUPO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRV_GRUPO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_GRUPO,PRV_NOME_GRUPO")] PRV_GRUPO pRV_GRUPO)
        {
            if (ModelState.IsValid)
            {
                //db.PRV_GRUPO.Add(pRV_GRUPO);
                //db.SaveChanges();
                repGrupo.Adicionar(pRV_GRUPO);
                repGrupo.SalvarTodos();
                return RedirectToAction("Index");
            }

            return View(pRV_GRUPO);
        }

        // GET: PRV_GRUPO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_GRUPO pRV_GRUPO = db.PRV_GRUPO.Find(id);
            PRV_GRUPO pRV_GRUPO = repGrupo.Find(id);
            if (pRV_GRUPO == null)
            {
                return HttpNotFound();
            }
            return View(pRV_GRUPO);
        }

        // POST: PRV_GRUPO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_GRUPO,PRV_NOME_GRUPO")] PRV_GRUPO pRV_GRUPO)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(pRV_GRUPO).State = EntityState.Modified;
                //db.SaveChanges();
                repGrupo.Atualizar(pRV_GRUPO);
                repGrupo.SalvarTodos();
                return RedirectToAction("Index");
            }
            return View(pRV_GRUPO);
        }

        // GET: PRV_GRUPO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PRV_GRUPO pRV_GRUPO = db.PRV_GRUPO.Find(id);
            PRV_GRUPO pRV_GRUPO = repGrupo.Find(id);
            if (pRV_GRUPO == null)
            {
                return HttpNotFound();
            }
            return View(pRV_GRUPO);
        }

        // POST: PRV_GRUPO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //PRV_GRUPO pRV_GRUPO = db.PRV_GRUPO.Find(id);
            //db.PRV_GRUPO.Remove(pRV_GRUPO);
            //db.SaveChanges();
            PRV_GRUPO pRV_GRUPO = repGrupo.Find(id);
            repGrupo.Excluir(g => g == pRV_GRUPO);
            repGrupo.SalvarTodos();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            repGrupo.Dispose();
            base.Dispose(disposing);
        }
    }
}
