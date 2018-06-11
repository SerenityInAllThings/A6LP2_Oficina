using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Oficina_codeFirst.Models;

namespace Oficina_codeFirst.Controllers
{
    public class PecaController : Controller
    {
        private OficinaContext db = new OficinaContext();

        // GET: /Peca/
        public ActionResult Index()
        {
            var peca = db.Peca.Include(p => p.Atendimento).Include(p => p.TipoPea);
            return View(peca.ToList());
        }

        // GET: /Peca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peca peca = db.Peca.Find(id);
            if (peca == null)
            {
                return HttpNotFound();
            }
            return View(peca);
        }

        // GET: /Peca/Create
        public ActionResult Create()
        {
            ViewBag.AtendimentoOid = new SelectList(db.Atendimentos, "Oid", "Codigo");
            ViewBag.TipoPecaOid = new SelectList(db.TipoPeca, "Oid", "Nome");
            return View();
        }

        // POST: /Peca/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Oid,Codigo,AtendimentoOid,TipoPecaOid")] Peca peca)
        {
            if (ModelState.IsValid)
            {
                db.Peca.Add(peca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AtendimentoOid = new SelectList(db.Atendimentos, "Oid", "Codigo", peca.AtendimentoOid);
            ViewBag.TipoPecaOid = new SelectList(db.TipoPeca, "Oid", "Nome", peca.TipoPecaOid);
            return View(peca);
        }

        // GET: /Peca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peca peca = db.Peca.Find(id);
            if (peca == null)
            {
                return HttpNotFound();
            }
            ViewBag.AtendimentoOid = new SelectList(db.Atendimentos, "Oid", "Codigo", peca.AtendimentoOid);
            ViewBag.TipoPecaOid = new SelectList(db.TipoPeca, "Oid", "Nome", peca.TipoPecaOid);
            return View(peca);
        }

        // POST: /Peca/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Oid,Codigo,AtendimentoOid,TipoPecaOid")] Peca peca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AtendimentoOid = new SelectList(db.Atendimentos, "Oid", "Codigo", peca.AtendimentoOid);
            ViewBag.TipoPecaOid = new SelectList(db.TipoPeca, "Oid", "Nome", peca.TipoPecaOid);
            return View(peca);
        }

        // GET: /Peca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peca peca = db.Peca.Find(id);
            if (peca == null)
            {
                return HttpNotFound();
            }
            return View(peca);
        }

        // POST: /Peca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Peca peca = db.Peca.Find(id);
            db.Peca.Remove(peca);
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
