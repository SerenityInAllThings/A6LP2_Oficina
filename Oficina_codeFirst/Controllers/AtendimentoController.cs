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
    public class AtendimentoController : BaseController
    {
        private OficinaContext db = new OficinaContext();

        // GET: /Atendimento/
        public ActionResult Index()
        {
            var atendimentos = db.Atendimentos.Include(a => a.Carro).Include(a => a.Fatura);
            return View(atendimentos.ToList());
        }

        // GET: /Atendimento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atendimento atendimento = db.Atendimentos.Find(id);
            if (atendimento == null)
            {
                return HttpNotFound();
            }
            return View(atendimento);
        }

        // GET: /Atendimento/Create
        public ActionResult Create()
        {
            ViewBag.CarroOid = new SelectList(db.Carros, "Oid", "Placa");
            ViewBag.Oid = new SelectList(db.Fatura, "Oid", "TipoPagamento");
            return View();
        }

        // POST: /Atendimento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Oid,Codigo,DataInicio,DataFim,CarroOid")] Atendimento atendimento)
        {
            if (ModelState.IsValid)
            {
                atendimento.Codigo = Guid.NewGuid().ToString().Substring(0, 8);

                db.Atendimentos.Add(atendimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarroOid = new SelectList(db.Carros, "Oid", "Placa", atendimento.CarroOid);
            ViewBag.Oid = new SelectList(db.Fatura, "Oid", "TipoPagamento", atendimento.Oid);
            return View(atendimento);
        }

        // GET: /Atendimento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atendimento atendimento = db.Atendimentos.Find(id);
            if (atendimento == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarroOid = new SelectList(db.Carros, "Oid", "Placa", atendimento.CarroOid);
            ViewBag.Oid = new SelectList(db.Fatura, "Oid", "TipoPagamento", atendimento.Oid);
            return View(atendimento);
        }

        // POST: /Atendimento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Oid,Codigo,DataInicio,DataFim,CarroOid")] Atendimento atendimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atendimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarroOid = new SelectList(db.Carros, "Oid", "Placa", atendimento.CarroOid);
            ViewBag.Oid = new SelectList(db.Fatura, "Oid", "TipoPagamento", atendimento.Oid);
            return View(atendimento);
        }

        // GET: /Atendimento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atendimento atendimento = db.Atendimentos.Find(id);
            if (atendimento == null)
            {
                return HttpNotFound();
            }
            return View(atendimento);
        }

        // POST: /Atendimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atendimento atendimento = db.Atendimentos.Find(id);
            db.Atendimentos.Remove(atendimento);
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
