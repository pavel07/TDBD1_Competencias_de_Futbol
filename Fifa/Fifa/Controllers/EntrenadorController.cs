using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fifa.Models;

namespace Fifa.Controllers
{
    public class EntrenadorController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Entrenador/

        public ActionResult Index()
        {
            var entrenador = db.ENTRENADOR.Include(e => e.PAIS);
            return View(entrenador.ToList());
        }

        //
        // GET: /Entrenador/Details/5

        public ActionResult Details(int id = 0)
        {
            ENTRENADOR entrenador = db.ENTRENADOR.Find(id);
            if (entrenador == null)
            {
                return HttpNotFound();
            }
            return View(entrenador);
        }

        //
        // GET: /Entrenador/Create

        public ActionResult Create()
        {
            ViewBag.ID_PAIS = new SelectList(db.PAIS, "ID_PAIS", "NOMBRE");
            return View();
        }

        //
        // POST: /Entrenador/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ENTRENADOR entrenador)
        {
            if (ModelState.IsValid)
            {
                db.ENTRENADOR.Add(entrenador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PAIS = new SelectList(db.PAIS, "ID_PAIS", "NOMBRE", entrenador.ID_PAIS);
            return View(entrenador);
        }

        //
        // GET: /Entrenador/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ENTRENADOR entrenador = db.ENTRENADOR.Find(id);
            if (entrenador == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PAIS = new SelectList(db.PAIS, "ID_PAIS", "NOMBRE", entrenador.ID_PAIS);
            return View(entrenador);
        }

        //
        // POST: /Entrenador/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ENTRENADOR entrenador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrenador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PAIS = new SelectList(db.PAIS, "ID_PAIS", "NOMBRE", entrenador.ID_PAIS);
            return View(entrenador);
        }

        //
        // GET: /Entrenador/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ENTRENADOR entrenador = db.ENTRENADOR.Find(id);
            if (entrenador == null)
            {
                return HttpNotFound();
            }
            return View(entrenador);
        }

        //
        // POST: /Entrenador/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ENTRENADOR entrenador = db.ENTRENADOR.Find(id);
            db.ENTRENADOR.Remove(entrenador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}