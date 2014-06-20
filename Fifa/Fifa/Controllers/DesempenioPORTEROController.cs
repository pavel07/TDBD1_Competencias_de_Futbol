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
    public class DesempenioPORTEROController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /DesempenioPORTERO/

        public ActionResult Index()
        {
            var desempenio_portero = db.DESEMPENIO_PORTERO.Include(d => d.RESULTADO).Include(d => d.JUGADOR);
            return View(desempenio_portero.ToList());
        }

        //
        // GET: /DesempenioPORTERO/Create

        public ActionResult Create()
        {
            ViewBag.ID_RESULTADO = new SelectList(db.RESULTADO, "ID_RESULTADO", "ID_RESULTADO");
            ViewBag.ID_JUGADOR = new SelectList(db.JUGADOR, "ID_JUGADOR", "NOMBRE");
            return View();
        }

        //
        // POST: /DesempenioPORTERO/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DESEMPENIO_PORTERO desempenio_portero)
        {
            if (ModelState.IsValid)
            {
                db.SP_DESEMPENIO_PORTERO_INSERT(desempenio_portero.ID_JUGADOR, desempenio_portero.ID_RESULTADO,
                    desempenio_portero.CAPACIDAD_ATAJAR, desempenio_portero.LUCHA1_1, desempenio_portero.ANTICIPACION,
                    desempenio_portero.REFLEJOS);
                return RedirectToAction("Index");
            }

            ViewBag.ID_RESULTADO = new SelectList(db.RESULTADO, "ID_RESULTADO", "ID_RESULTADO", desempenio_portero.ID_RESULTADO);
            ViewBag.ID_JUGADOR = new SelectList(db.JUGADOR, "ID_JUGADOR", "NOMBRE", desempenio_portero.ID_JUGADOR);
            return View(desempenio_portero);
        }

        //
        // GET: /DesempenioPORTERO/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DESEMPENIO_PORTERO desempenio_portero = db.DESEMPENIO_PORTERO.Find(id);
            if (desempenio_portero == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_RESULTADO = new SelectList(db.RESULTADO, "ID_RESULTADO", "ID_RESULTADO", desempenio_portero.ID_RESULTADO);
            ViewBag.ID_JUGADOR = new SelectList(db.JUGADOR, "ID_JUGADOR", "NOMBRE", desempenio_portero.ID_JUGADOR);
            return View(desempenio_portero);
        }

        //
        // POST: /DesempenioPORTERO/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DESEMPENIO_PORTERO desempenio_portero)
        {
            if (ModelState.IsValid)
            {
                db.SP_DESEMPENIO_PORTERO_UPDATE(desempenio_portero.ID_JUGADOR, desempenio_portero.ID_RESULTADO,
                    desempenio_portero.CAPACIDAD_ATAJAR, desempenio_portero.LUCHA1_1, desempenio_portero.ANTICIPACION,
                    desempenio_portero.REFLEJOS);
                return RedirectToAction("Index");
            }
            ViewBag.ID_RESULTADO = new SelectList(db.RESULTADO, "ID_RESULTADO", "ID_RESULTADO", desempenio_portero.ID_RESULTADO);
            ViewBag.ID_JUGADOR = new SelectList(db.JUGADOR, "ID_JUGADOR", "NOMBRE", desempenio_portero.ID_JUGADOR);
            return View(desempenio_portero);
        }

        //
        // GET: /DesempenioPORTERO/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DESEMPENIO_PORTERO desempenio_portero = db.DESEMPENIO_PORTERO.Find(id);
            if (desempenio_portero == null)
            {
                return HttpNotFound();
            }
            return View(desempenio_portero);
        }

        //
        // POST: /DesempenioPORTERO/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DESEMPENIO_PORTERO desempenio_portero = db.DESEMPENIO_PORTERO.Find(id);
            db.SP_DESEMPENIO_PORTERO_DELETE(desempenio_portero.ID_JUGADOR, desempenio_portero.ID_RESULTADO);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}