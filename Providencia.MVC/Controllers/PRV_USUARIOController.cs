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
    public class PRV_USUARIOController : Controller
    {
        private BancoContexto db = new BancoContexto();

        // GET: PRV_USUARIO
        public ActionResult Index()
        {
            return View(db.PRV_USUARIO.ToList());
        }

        // GET: PRV_USUARIO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_USUARIO pRV_USUARIO = db.PRV_USUARIO.Find(id);
            if (pRV_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(pRV_USUARIO);
        }

        // GET: PRV_USUARIO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRV_USUARIO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_USUARIO,PRV_NOME_USUARIO,PRV_CPF_USUARIO,PRV_DATA_NASCIMENTO,PRV_EMAIL_USUARIO,PRV_LOGIN_USUARIO,PRV_SENHA_USUARIO,PRV_CARGO_USUARIO,PRV_SETOR_AREA_USUARIO")] PRV_USUARIO pRV_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.PRV_USUARIO.Add(pRV_USUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pRV_USUARIO);
        }

        // GET: PRV_USUARIO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_USUARIO pRV_USUARIO = db.PRV_USUARIO.Find(id);
            if (pRV_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(pRV_USUARIO);
        }

        // POST: PRV_USUARIO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_USUARIO,PRV_NOME_USUARIO,PRV_CPF_USUARIO,PRV_DATA_NASCIMENTO,PRV_EMAIL_USUARIO,PRV_LOGIN_USUARIO,PRV_SENHA_USUARIO,PRV_CARGO_USUARIO,PRV_SETOR_AREA_USUARIO")] PRV_USUARIO pRV_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRV_USUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pRV_USUARIO);
        }

        // GET: PRV_USUARIO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_USUARIO pRV_USUARIO = db.PRV_USUARIO.Find(id);
            if (pRV_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(pRV_USUARIO);
        }

        // POST: PRV_USUARIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRV_USUARIO pRV_USUARIO = db.PRV_USUARIO.Find(id);
            db.PRV_USUARIO.Remove(pRV_USUARIO);
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
