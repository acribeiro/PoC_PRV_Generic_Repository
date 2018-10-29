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
    public class PRV_BENEFICIOS_FAMILIAController : Controller
    {
        private BancoContexto db = new DAL.Contexto.BancoContexto();
        private readonly BeneficiosFamiliaRepositorio repBeneficiosFamilia = new BeneficiosFamiliaRepositorio();

        // GET: PRV_BENEFICIOS_FAMILIA
        public ActionResult Index()
        {
            var pRV_BENEFICIOS_FAMILIA = db.PRV_BENEFICIOS_FAMILIA.Include(p => p.PRV_BENEFICIOS).Include(p => p.PRV_CONSTITUICAO_FAMILIAR);
            return View(pRV_BENEFICIOS_FAMILIA.ToList());
        }

        // GET: PRV_BENEFICIOS_FAMILIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_BENEFICIOS_FAMILIA pRV_BENEFICIOS_FAMILIA = repBeneficiosFamilia.Find(id);
            if (pRV_BENEFICIOS_FAMILIA == null)
            {
                return HttpNotFound();
            }
            return View(pRV_BENEFICIOS_FAMILIA);
        }

        // GET: PRV_BENEFICIOS_FAMILIA/Create
        public ActionResult Create()
        {
            ViewBag.PRV_ID_BENEFICIO = new SelectList(db.PRV_BENEFICIOS, "PRV_ID_BENEFICIOS", "PRV_DESCRICAO_BENEFICIOS");
            ViewBag.PRV_ID_MEMBRO_FAMILIA = new SelectList(db.PRV_CONSTITUICAO_FAMILIAR, "PRV_ID_CONSTITUICAO_FAMILIAR", "PRV_NOME_MEMBRO_FAMILIA");
            return View();
        }

        // POST: PRV_BENEFICIOS_FAMILIA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRV_ID_BENEFICIOS_FAMILIA,PRV_ID_MEMBRO_FAMILIA,PRV_ID_BENEFICIO")] PRV_BENEFICIOS_FAMILIA pRV_BENEFICIOS_FAMILIA)
        {
            if (ModelState.IsValid)
            {
                //db.PRV_BENEFICIOS_FAMILIA.Add(pRV_BENEFICIOS_FAMILIA);
                //db.SaveChanges();
                repBeneficiosFamilia.Adicionar(pRV_BENEFICIOS_FAMILIA);
                repBeneficiosFamilia.SalvarTodos();
                return RedirectToAction("Index");
            }

            ViewBag.PRV_ID_BENEFICIO = new SelectList(db.PRV_BENEFICIOS, "PRV_ID_BENEFICIOS", "PRV_DESCRICAO_BENEFICIOS", pRV_BENEFICIOS_FAMILIA.PRV_ID_BENEFICIO);
            ViewBag.PRV_ID_MEMBRO_FAMILIA = new SelectList(db.PRV_CONSTITUICAO_FAMILIAR, "PRV_ID_CONSTITUICAO_FAMILIAR", "PRV_NOME_MEMBRO_FAMILIA", pRV_BENEFICIOS_FAMILIA.PRV_ID_MEMBRO_FAMILIA);
            return View(pRV_BENEFICIOS_FAMILIA);
        }

        // GET: PRV_BENEFICIOS_FAMILIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_BENEFICIOS_FAMILIA pRV_BENEFICIOS_FAMILIA = repBeneficiosFamilia.Find(id);
            if (pRV_BENEFICIOS_FAMILIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRV_ID_BENEFICIO = new SelectList(db.PRV_BENEFICIOS, "PRV_ID_BENEFICIOS", "PRV_DESCRICAO_BENEFICIOS", pRV_BENEFICIOS_FAMILIA.PRV_ID_BENEFICIO);
            ViewBag.PRV_ID_MEMBRO_FAMILIA = new SelectList(db.PRV_CONSTITUICAO_FAMILIAR, "PRV_ID_CONSTITUICAO_FAMILIAR", "PRV_NOME_MEMBRO_FAMILIA", pRV_BENEFICIOS_FAMILIA.PRV_ID_MEMBRO_FAMILIA);
            return View(pRV_BENEFICIOS_FAMILIA);
        }

        // POST: PRV_BENEFICIOS_FAMILIA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRV_ID_BENEFICIOS_FAMILIA,PRV_ID_MEMBRO_FAMILIA,PRV_ID_BENEFICIO")] PRV_BENEFICIOS_FAMILIA pRV_BENEFICIOS_FAMILIA)
        {
            if (ModelState.IsValid)
            {
                repBeneficiosFamilia.Atualizar(pRV_BENEFICIOS_FAMILIA);
                repBeneficiosFamilia.SalvarTodos();
                return RedirectToAction("Index");
            }
            ViewBag.PRV_ID_BENEFICIO = new SelectList(db.PRV_BENEFICIOS, "PRV_ID_BENEFICIOS", "PRV_DESCRICAO_BENEFICIOS", pRV_BENEFICIOS_FAMILIA.PRV_ID_BENEFICIO);
            ViewBag.PRV_ID_MEMBRO_FAMILIA = new SelectList(db.PRV_CONSTITUICAO_FAMILIAR, "PRV_ID_CONSTITUICAO_FAMILIAR", "PRV_NOME_MEMBRO_FAMILIA", pRV_BENEFICIOS_FAMILIA.PRV_ID_MEMBRO_FAMILIA);
            return View(pRV_BENEFICIOS_FAMILIA);
        }

        // GET: PRV_BENEFICIOS_FAMILIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRV_BENEFICIOS_FAMILIA pRV_BENEFICIOS_FAMILIA = repBeneficiosFamilia.Find(id);
            if (pRV_BENEFICIOS_FAMILIA == null)
            {
                return HttpNotFound();
            }
            return View(pRV_BENEFICIOS_FAMILIA);
        }

        // POST: PRV_BENEFICIOS_FAMILIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRV_BENEFICIOS_FAMILIA pRV_BENEFICIOS_FAMILIA = repBeneficiosFamilia.Find(id);
            repBeneficiosFamilia.Excluir(bf => bf == pRV_BENEFICIOS_FAMILIA);
            repBeneficiosFamilia.SalvarTodos();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            repBeneficiosFamilia.Dispose();
            base.Dispose(disposing);
        }
    }
}
