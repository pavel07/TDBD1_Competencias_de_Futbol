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
    public class EquipoJugadorController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /EquipoJugador/

        public ActionResult Index()
        {
            var equipo_jugador = db.EQUIPO_JUGADOR.Include(e => e.EQUIPO).Include(e => e.JUGADOR);
            return View(equipo_jugador.ToList());
        }

        //
        // GET: /EquipoJugador/Details/5

        public ActionResult Details(int id = 0)
        {
            EQUIPO_JUGADOR equipo_jugador = db.EQUIPO_JUGADOR.Find(id);
            if (equipo_jugador == null)
            {
                return HttpNotFound();
            }
            return View(equipo_jugador);
        }

        //
        // GET: /EquipoJugador/Create

        public ActionResult Create()
        {
            ViewBag.ID_EQUIPO = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBRE");
            ViewBag.ID_JUGADOR = new SelectList(db.JUGADOR, "ID_JUGADOR", "NOMBRE");
            return View();
        }

        //
        // POST: /EquipoJugador/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EQUIPO_JUGADOR equipo_jugador)
        {
            if (ModelState.IsValid)
            {
                db.EQUIPO_JUGADOR.Add(equipo_jugador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_EQUIPO = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBRE", equipo_jugador.ID_EQUIPO);
            ViewBag.ID_JUGADOR = new SelectList(db.JUGADOR, "ID_JUGADOR", "NOMBRE", equipo_jugador.ID_JUGADOR);
            return View(equipo_jugador);
        }

        //
        // GET: /EquipoJugador/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EQUIPO_JUGADOR equipo_jugador = db.EQUIPO_JUGADOR.Find(id);
            if (equipo_jugador == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_EQUIPO = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBRE", equipo_jugador.ID_EQUIPO);
            ViewBag.ID_JUGADOR = new SelectList(db.JUGADOR, "ID_JUGADOR", "NOMBRE", equipo_jugador.ID_JUGADOR);
            return View(equipo_jugador);
        }

        //
        // POST: /EquipoJugador/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EQUIPO_JUGADOR equipo_jugador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipo_jugador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_EQUIPO = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBRE", equipo_jugador.ID_EQUIPO);
            ViewBag.ID_JUGADOR = new SelectList(db.JUGADOR, "ID_JUGADOR", "NOMBRE", equipo_jugador.ID_JUGADOR);
            return View(equipo_jugador);
        }

        //
        // GET: /EquipoJugador/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EQUIPO_JUGADOR equipo_jugador = db.EQUIPO_JUGADOR.Find(id);
            if (equipo_jugador == null)
            {
                return HttpNotFound();
            }
            return View(equipo_jugador);
        }

        //
        // POST: /EquipoJugador/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EQUIPO_JUGADOR equipo_jugador = db.EQUIPO_JUGADOR.Find(id);
            db.EQUIPO_JUGADOR.Remove(equipo_jugador);
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