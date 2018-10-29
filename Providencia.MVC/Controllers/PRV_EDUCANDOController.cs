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
    public class PRV_EDUCANDOController : Controller
    {
        private BancoContexto db = new BancoContexto();

        // GET: PRV_EDUCANDO
        public ActionResult Index()
        {
            var pRV_EDUCANDO = db.PRV_EDUCANDO.Include(p => p.PRV_ESTADO_CIVIL).Include(p => p.PRV_MORADIA1).Include(p => p.PRV_TIPO_DE_FAMILIA);
            return View(pRV_EDUCANDO.ToList());
        }

        // GET: PRV_EDUCANDO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_EDUCANDO pRV_EDUCANDO = db.PRV_EDUCANDO.Find(id);
            if (pRV_EDUCANDO == null)
            {
                return HttpNotFound();
            }
            return View(pRV_EDUCANDO);
        }

        // GET: PRV_EDUCANDO/Create
        public ActionResult Create()
        {
            ViewBag.PRV_ID_ESTADO_CIVIL_RESPONSAVEL = new SelectList(db.PRV_ESTADO_CIVIL, "PRV_ID_ESTADO_CIVIL", "PRV_DESCRICAO_ESTADO_CIVIL");
            ViewBag.PRV_ID_MORADIA_RESPONSAVEL = new SelectList(db.PRV_MORADIA, "PRV_ID_MORADIA", "PRV_ID_MORADIA");
            ViewBag.PRV_ID_TIPO_DE_FAMILIA = new SelectList(db.PRV_TIPO_DE_FAMILIA, "PRV_ID_TIPO_DE_FAMILIA", "PRV_DESCRICAO_TIPO_DE_FAMILIA");
            return View();
        }

        // POST: PRV_EDUCANDO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_EDUCANDO,PRV_DATA_NASCIMENTO_EDUCANDO,PRV_NOME_RESPONSAVEL,PRV_TELEFONE_RESPONSAVEL,PRV_NOME_MAE,PRV_TELEFONE_MAE,PRV_NOME_PAI,PRV_TELEFONE_PAI,PRV_TELEFONE_RESIDENCIAL,PRV_NOME_RUA,PRV_NUMERO,PRV_BAIRRO,PRV_CEP,PRV_NA_AUSENCIA_RESPONSAVEL,PRV_ID_ESTADO_CIVIL_RESPONSAVEL,PRV_ID_TIPO_DE_FAMILIA,PRV_ID_MORADIA_RESPONSAVEL,PRV_NOME_EDUCANDO")] PRV_EDUCANDO pRV_EDUCANDO)
        {
            if (ModelState.IsValid)
            {
                db.PRV_EDUCANDO.Add(pRV_EDUCANDO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRV_ID_ESTADO_CIVIL_RESPONSAVEL = new SelectList(db.PRV_ESTADO_CIVIL, "PRV_ID_ESTADO_CIVIL", "PRV_DESCRICAO_ESTADO_CIVIL", pRV_EDUCANDO.PRV_ID_ESTADO_CIVIL_RESPONSAVEL);
            ViewBag.PRV_ID_MORADIA_RESPONSAVEL = new SelectList(db.PRV_MORADIA, "PRV_ID_MORADIA", "PRV_ID_MORADIA", pRV_EDUCANDO.PRV_ID_MORADIA_RESPONSAVEL);
            ViewBag.PRV_ID_TIPO_DE_FAMILIA = new SelectList(db.PRV_TIPO_DE_FAMILIA, "PRV_ID_TIPO_DE_FAMILIA", "PRV_DESCRICAO_TIPO_DE_FAMILIA", pRV_EDUCANDO.PRV_ID_TIPO_DE_FAMILIA);
            return View(pRV_EDUCANDO);
        }

        // GET: PRV_EDUCANDO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_EDUCANDO pRV_EDUCANDO = db.PRV_EDUCANDO.Find(id);
            if (pRV_EDUCANDO == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRV_ID_ESTADO_CIVIL_RESPONSAVEL = new SelectList(db.PRV_ESTADO_CIVIL, "PRV_ID_ESTADO_CIVIL", "PRV_DESCRICAO_ESTADO_CIVIL", pRV_EDUCANDO.PRV_ID_ESTADO_CIVIL_RESPONSAVEL);
            ViewBag.PRV_ID_MORADIA_RESPONSAVEL = new SelectList(db.PRV_MORADIA, "PRV_ID_MORADIA", "PRV_ID_MORADIA", pRV_EDUCANDO.PRV_ID_MORADIA_RESPONSAVEL);
            ViewBag.PRV_ID_TIPO_DE_FAMILIA = new SelectList(db.PRV_TIPO_DE_FAMILIA, "PRV_ID_TIPO_DE_FAMILIA", "PRV_DESCRICAO_TIPO_DE_FAMILIA", pRV_EDUCANDO.PRV_ID_TIPO_DE_FAMILIA);
            return View(pRV_EDUCANDO);
        }

        // POST: PRV_EDUCANDO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_EDUCANDO,PRV_DATA_NASCIMENTO_EDUCANDO,PRV_NOME_RESPONSAVEL,PRV_TELEFONE_RESPONSAVEL,PRV_NOME_MAE,PRV_TELEFONE_MAE,PRV_NOME_PAI,PRV_TELEFONE_PAI,PRV_TELEFONE_RESIDENCIAL,PRV_NOME_RUA,PRV_NUMERO,PRV_BAIRRO,PRV_CEP,PRV_NA_AUSENCIA_RESPONSAVEL,PRV_ID_ESTADO_CIVIL_RESPONSAVEL,PRV_ID_TIPO_DE_FAMILIA,PRV_ID_MORADIA_RESPONSAVEL,PRV_NOME_EDUCANDO")] PRV_EDUCANDO pRV_EDUCANDO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRV_EDUCANDO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRV_ID_ESTADO_CIVIL_RESPONSAVEL = new SelectList(db.PRV_ESTADO_CIVIL, "PRV_ID_ESTADO_CIVIL", "PRV_DESCRICAO_ESTADO_CIVIL", pRV_EDUCANDO.PRV_ID_ESTADO_CIVIL_RESPONSAVEL);
            ViewBag.PRV_ID_MORADIA_RESPONSAVEL = new SelectList(db.PRV_MORADIA, "PRV_ID_MORADIA", "PRV_ID_MORADIA", pRV_EDUCANDO.PRV_ID_MORADIA_RESPONSAVEL);
            ViewBag.PRV_ID_TIPO_DE_FAMILIA = new SelectList(db.PRV_TIPO_DE_FAMILIA, "PRV_ID_TIPO_DE_FAMILIA", "PRV_DESCRICAO_TIPO_DE_FAMILIA", pRV_EDUCANDO.PRV_ID_TIPO_DE_FAMILIA);
            return View(pRV_EDUCANDO);
        }

        // GET: PRV_EDUCANDO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_EDUCANDO pRV_EDUCANDO = db.PRV_EDUCANDO.Find(id);
            if (pRV_EDUCANDO == null)
            {
                return HttpNotFound();
            }
            return View(pRV_EDUCANDO);
        }

        // POST: PRV_EDUCANDO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRV_EDUCANDO pRV_EDUCANDO = db.PRV_EDUCANDO.Find(id);
            db.PRV_EDUCANDO.Remove(pRV_EDUCANDO);
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
