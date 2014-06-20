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
    public class EstadioController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Estadio/

        public ActionResult Index()
        {
            var estadio = db.ESTADIO.Include(e => e.CIUDAD);
            return View(estadio.ToList());
        }

        //
        // GET: /Estadio/Create

        public ActionResult Create()
        {
            ViewBag.ID_CIUDAD = new SelectList(db.CIUDAD, "ID_CIUDAD", "NOMBRE");
            return View();
        }

        //
        // POST: /Estadio/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ESTADIO estadio)
        {
            if (ModelState.IsValid)
            {
                db.SP_ESTADIO_INSERT(estadio.ID_CIUDAD, estadio.NOMBRE, estadio.CAPACIDAD, estadio.FECHA_INAUGURACION,
                    estadio.HISTORIA);
                return RedirectToAction("Index");
            }

            ViewBag.ID_CIUDAD = new SelectList(db.CIUDAD, "ID_CIUDAD", "NOMBRE", estadio.ID_CIUDAD);
            return View(estadio);
        }

        //
        // GET: /Estadio/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ESTADIO estadio = db.ESTADIO.Find(id);
            if (estadio == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CIUDAD = new SelectList(db.CIUDAD, "ID_CIUDAD", "NOMBRE", estadio.ID_CIUDAD);
            return View(estadio);
        }

        //
        // POST: /Estadio/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ESTADIO estadio)
        {
            if (ModelState.IsValid)
            {
                db.SP_ESTADIO_UPDATE(estadio.ID_CIUDAD, estadio.NOMBRE, estadio.CAPACIDAD, estadio.FECHA_INAUGURACION,
                    estadio.HISTORIA, estadio.ID_ESTADIO);
                return RedirectToAction("Index");
            }
            ViewBag.ID_CIUDAD = new SelectList(db.CIUDAD, "ID_CIUDAD", "NOMBRE", estadio.ID_CIUDAD);
            return View(estadio);
        }

        //
        // GET: /Estadio/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ESTADIO estadio = db.ESTADIO.Find(id);
            if (estadio == null)
            {
                return HttpNotFound();
            }
            return View(estadio);
        }

        //
        // POST: /Estadio/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESTADIO estadio = db.ESTADIO.Find(id);
            db.SP_ESTADIO_DELETE(estadio.ID_ESTADIO);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}