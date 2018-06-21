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
    public class TipoPecaController : BaseController
    {
        private OficinaContext db = new OficinaContext();

        // GET: /TipoPeca/
        public ActionResult Index()
        {
            return View(db.TipoPeca.ToList());
        }

        // GET: /TipoPeca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPeca tipopeca = db.TipoPeca.Find(id);
            if (tipopeca == null)
            {
                return HttpNotFound();
            }
            return View(tipopeca);
        }

        // GET: /TipoPeca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoPeca/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Oid,Nome,Quantidade")] TipoPeca tipopeca)
        {
            if (ModelState.IsValid)
            {
                db.TipoPeca.Add(tipopeca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipopeca);
        }

        // GET: /TipoPeca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPeca tipopeca = db.TipoPeca.Find(id);
            if (tipopeca == null)
            {
                return HttpNotFound();
            }
            return View(tipopeca);
        }

        // POST: /TipoPeca/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Oid,Nome,Quantidade")] TipoPeca tipopeca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipopeca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipopeca);
        }

        // GET: /TipoPeca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPeca tipopeca = db.TipoPeca.Find(id);
            if (tipopeca == null)
            {
                return HttpNotFound();
            }
            return View(tipopeca);
        }

        // POST: /TipoPeca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPeca tipopeca = db.TipoPeca.Find(id);
            db.TipoPeca.Remove(tipopeca);
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
