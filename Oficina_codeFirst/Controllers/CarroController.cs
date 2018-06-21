﻿using System;
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
    public class CarroController : BaseController
    {
        private OficinaContext db = new OficinaContext();

        // GET: /Carro/
        public ActionResult Index()
        {
            var carros = db.Carros.Include(c => c.Cliente);
            return View(carros.ToList());
        }

        // GET: /Carro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.Carros.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // GET: /Carro/Create
        public ActionResult Create()
        {
            ViewBag.ClienteOid = new SelectList(db.Clientes, "Oid", "Nome");
            return View();
        }

        // POST: /Carro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Oid,Placa,Cor,Modelo,Marca,Ano,Quilometragem,ClienteOid")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                db.Carros.Add(carro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteOid = new SelectList(db.Clientes, "Oid", "Nome", carro.ClienteOid);
            return View(carro);
        }

        // GET: /Carro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.Carros.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteOid = new SelectList(db.Clientes, "Oid", "Nome", carro.ClienteOid);
            return View(carro);
        }

        // POST: /Carro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Oid,Placa,Cor,Modelo,Marca,Ano,Quilometragem,ClienteOid")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteOid = new SelectList(db.Clientes, "Oid", "Nome", carro.ClienteOid);
            return View(carro);
        }

        // GET: /Carro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.Carros.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: /Carro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carro carro = db.Carros.Find(id);
            db.Carros.Remove(carro);
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
