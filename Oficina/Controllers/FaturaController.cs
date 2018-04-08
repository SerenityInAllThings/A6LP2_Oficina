using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Oficina.Models;

namespace Oficina.Controllers
{
    public class FaturaController : Controller
    {
        private oficinaContainer db = new oficinaContainer();

        // GET: /Fatura/
        public ActionResult Index()
        {
            return View(db.Faturas.ToList());
        }

        // GET: /Fatura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fatura fatura = db.Faturas.Find(id);
            if (fatura == null)
            {
                return HttpNotFound();
            }
            return View(fatura);
        }

        // GET: /Fatura/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Fatura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Oid,ValorRecebido,TipoPagamento")] Fatura fatura)
        {
            if (ModelState.IsValid)
            {
                db.Faturas.Add(fatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fatura);
        }

        // GET: /Fatura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fatura fatura = db.Faturas.Find(id);
            if (fatura == null)
            {
                return HttpNotFound();
            }
            return View(fatura);
        }

        // POST: /Fatura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Oid,ValorRecebido,TipoPagamento")] Fatura fatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fatura);
        }

        // GET: /Fatura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fatura fatura = db.Faturas.Find(id);
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
            Fatura fatura = db.Faturas.Find(id);
            db.Faturas.Remove(fatura);
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
