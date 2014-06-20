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
    public class EquipoController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Equipo/

        public ActionResult Index()
        {
            var equipo = db.EQUIPO.Include(e => e.CIUDAD).Include(e => e.ENTRENADOR);
            return View(equipo.ToList());
        }


        //
        // GET: /Equipo/Create

        public ActionResult Create()
        {
            ViewBag.ID_CIUDAD = new SelectList(db.CIUDAD, "ID_CIUDAD", "NOMBRE");
            ViewBag.ID_ENTRENADOR = new SelectList(db.ENTRENADOR, "ID_ENTRENADOR", "NOMBRE");
            return View();
        }

        //
        // POST: /Equipo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EQUIPO equipo)
        {
            if (ModelState.IsValid)
            {
                db.SP_EQUIPO_INSERT(equipo.ID_CIUDAD, equipo.ID_ENTRENADOR, equipo.NOMBRE, equipo.FECHA_FUNDACION,
                    equipo.NUMERO_COPASGANADAS, equipo.LOGOTIPO, equipo.TIPO);
                return RedirectToAction("Index");
            }

            ViewBag.ID_CIUDAD = new SelectList(db.CIUDAD, "ID_CIUDAD", "NOMBRE", equipo.ID_CIUDAD);
            ViewBag.ID_ENTRENADOR = new SelectList(db.ENTRENADOR, "ID_ENTRENADOR", "NOMBRE", equipo.ID_ENTRENADOR);
            return View(equipo);
        }

        //
        // GET: /Equipo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EQUIPO equipo = db.EQUIPO.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CIUDAD = new SelectList(db.CIUDAD, "ID_CIUDAD", "NOMBRE", equipo.ID_CIUDAD);
            ViewBag.ID_ENTRENADOR = new SelectList(db.ENTRENADOR, "ID_ENTRENADOR", "NOMBRE", equipo.ID_ENTRENADOR);
            return View(equipo);
        }

        //
        // POST: /Equipo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EQUIPO equipo)
        {
            if (ModelState.IsValid)
            {
                db.SP_EQUIPO_UPDATE(equipo.ID_CIUDAD, equipo.ID_ENTRENADOR, equipo.NOMBRE, equipo.FECHA_FUNDACION,
                    equipo.NUMERO_COPASGANADAS, equipo.LOGOTIPO,equipo.ID_EQUIPO, equipo.TIPO);
                return RedirectToAction("Index");
            }
            ViewBag.ID_CIUDAD = new SelectList(db.CIUDAD, "ID_CIUDAD", "NOMBRE", equipo.ID_CIUDAD);
            ViewBag.ID_ENTRENADOR = new SelectList(db.ENTRENADOR, "ID_ENTRENADOR", "NOMBRE", equipo.ID_ENTRENADOR);
            return View(equipo);
        }

        //
        // GET: /Equipo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EQUIPO equipo = db.EQUIPO.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        //
        // POST: /Equipo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EQUIPO equipo = db.EQUIPO.Find(id);
            db.SP_EQUIPO_DELETE(equipo.ID_EQUIPO);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}