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
    public class FaturaController : BaseController
    {
        private OficinaContext db = new OficinaContext();

        // GET: /Fatura/
        public ActionResult Index()
        {
            var fatura = db.Fatura.Include(f => f.Atendimento);
            return View(fatura.ToList());
        }

        // GET: /Fatura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fatura fatura = db.Fatura.Find(id);
            if (fatura == null)
            {
                return HttpNotFound();
            }
            return View(fatura);
        }

        // GET: /Fatura/Create
        public ActionResult Create()
        {
            ViewBag.Oid = new SelectList(db.Atendimentos, "Oid", "Codigo");
            return View();
        }

        // POST: /Fatura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Oid,ValorRecebido,TipoPagamento,parcelas")] Fatura fatura)
        {
            if (ModelState.IsValid)
            {
                db.Fatura.Add(fatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Oid = new SelectList(db.Atendimentos, "Oid", "Codigo", fatura.Oid);
            return View(fatura);
        }

        // GET: /Fatura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fatura fatura = db.Fatura.Find(id);
            if (fatura == null)
            {
                return HttpNotFound();
            }
            ViewBag.Oid = new SelectList(db.Atendimentos, "Oid", "Codigo", fatura.Oid);
            return View(fatura);
        }

        // POST: /Fatura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Oid,ValorRecebido,TipoPagamento,parcelas")] Fatura fatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Oid = new SelectList(db.Atendimentos, "Oid", "Codigo", fatura.Oid);
            return View(fatura);
        }

        // GET: /Fatura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fatura fatura = db.Fatura.Find(id);
            if (fatura == null)
            {
                return HttpNotFound();
            }
            return View(fatura);
        }

        // POST: /Fatura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fatura fatura = db.Fatura.Find(id);
            db.Fatura.Remove(fatura);
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
