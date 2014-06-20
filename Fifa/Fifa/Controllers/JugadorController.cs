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
    public class JugadorController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Jugador/

        public ActionResult Index()
        {
            var jugador = db.JUGADOR.Include(j => j.PAIS);
            return View(jugador.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.ID_PAIS = new SelectList(db.PAIS, "ID_PAIS", "NOMBRE");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JUGADOR jugador)
        {
            if (ModelState.IsValid)
            {
                db.SP_JUGADOR_INSERT(jugador.ID_PAIS, jugador.NOMBRE, jugador.EDAD, jugador.PESO, jugador.POSICION,
                    jugador.CEDULA_IDENTIDAD, jugador.BIOGRAFIA, jugador.FOTO);
                return RedirectToAction("Index");
            }

            ViewBag.ID_PAIS = new SelectList(db.PAIS, "ID_PAIS", "NOMBRE", jugador.ID_PAIS);
            return View(jugador);
        }

        //
        // GET: /Jugador/Edit/5

        public ActionResult Edit(int id = 0)
        {
            JUGADOR jugador = db.JUGADOR.Find(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PAIS = new SelectList(db.PAIS, "ID_PAIS", "NOMBRE", jugador.ID_PAIS);
            return View(jugador);
        }

        //
        // POST: /Jugador/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JUGADOR jugador)
        {
            if (ModelState.IsValid)
            {
                db.SP_JUGADOR_UPDATE(jugador.ID_PAIS, jugador.NOMBRE, jugador.EDAD, jugador.PESO, jugador.POSICION,
                    jugador.CEDULA_IDENTIDAD, jugador.BIOGRAFIA, jugador.FOTO, jugador.ID_JUGADOR);
                return RedirectToAction("Index");
            }
            ViewBag.ID_PAIS = new SelectList(db.PAIS, "ID_PAIS", "NOMBRE", jugador.ID_PAIS);
            return View(jugador);
        }

        //
        // GET: /Jugador/Delete/5

        public ActionResult Delete(int id = 0)
        {
            JUGADOR jugador = db.JUGADOR.Find(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            return View(jugador);
        }

        //
        // POST: /Jugador/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JUGADOR jugador = db.JUGADOR.Find(id);
            db.SP_JUGADOR_DELETE(jugador.ID_JUGADOR);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}