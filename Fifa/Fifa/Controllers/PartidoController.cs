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
    public class PartidoController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Partido/

        public ActionResult Index()
        {
            var partido = db.PARTIDO.Include(p => p.COMPETENCIA).Include(p => p.EQUIPO).Include(p => p.EQUIPO1).Include(p => p.ESTADIO);
            return View(partido.ToList());
        }

        //
        // GET: /Partido/Create

        public ActionResult Create()
        {
            ViewBag.ID_COMPETENCIA = new SelectList(db.COMPETENCIA, "ID_COMPETENCIA", "NOMBRE");
            ViewBag.ID_EQUIPO_LOCAL = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBRE");
            ViewBag.ID_EQUIPO_VISITA = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBRE");
            ViewBag.ID_ESTADIO = new SelectList(db.ESTADIO, "ID_ESTADIO", "NOMBRE");
            return View();
        }

        //
        // POST: /Partido/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PARTIDO partido)
        {
            if (ModelState.IsValid)
            {
                db.SP_PARTIDO_INSERT(partido.ID_COMPETENCIA, partido.ID_ESTADIO, partido.ID_EQUIPO_LOCAL,
                    partido.ID_EQUIPO_VISITA,
                    partido.FECHA_PARTIDO, partido.HORA_INICIO, partido.ESTADO);
                return RedirectToAction("Index");
            }

            ViewBag.ID_COMPETENCIA = new SelectList(db.COMPETENCIA, "ID_COMPETENCIA", "NOMBRE", partido.ID_COMPETENCIA);
            ViewBag.ID_EQUIPO_LOCAL = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBRE", partido.ID_EQUIPO_LOCAL);
            ViewBag.ID_EQUIPO_VISITA = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBRE", partido.ID_EQUIPO_VISITA);
            ViewBag.ID_ESTADIO = new SelectList(db.ESTADIO, "ID_ESTADIO", "NOMBRE", partido.ID_ESTADIO);
            return View(partido);
        }

        //
        // GET: /Partido/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PARTIDO partido = db.PARTIDO.Find(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_COMPETENCIA = new SelectList(db.COMPETENCIA, "ID_COMPETENCIA", "NOMBRE", partido.ID_COMPETENCIA);
            ViewBag.ID_EQUIPO_LOCAL = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBRE", partido.ID_EQUIPO_LOCAL);
            ViewBag.ID_EQUIPO_VISITA = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBRE", partido.ID_EQUIPO_VISITA);
            ViewBag.ID_ESTADIO = new SelectList(db.ESTADIO, "ID_ESTADIO", "NOMBRE", partido.ID_ESTADIO);
            return View(partido);
        }

        //
        // POST: /Partido/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PARTIDO partido)
        {
            if (ModelState.IsValid)
            {
                db.SP_PARTIDO_UPDATE(partido.ID_COMPETENCIA, partido.ID_ESTADIO, partido.ID_EQUIPO_LOCAL,
                    partido.ID_EQUIPO_VISITA,
                    partido.FECHA_PARTIDO, partido.HORA_INICIO, partido.ESTADO, partido.ID_PARTIDO);
                return RedirectToAction("Index");
            }
            ViewBag.ID_COMPETENCIA = new SelectList(db.COMPETENCIA, "ID_COMPETENCIA", "NOMBRE", partido.ID_COMPETENCIA);
            ViewBag.ID_EQUIPO_LOCAL = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBRE", partido.ID_EQUIPO_LOCAL);
            ViewBag.ID_EQUIPO_VISITA = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBRE", partido.ID_EQUIPO_VISITA);
            ViewBag.ID_ESTADIO = new SelectList(db.ESTADIO, "ID_ESTADIO", "NOMBRE", partido.ID_ESTADIO);
            return View(partido);
        }

        //
        // GET: /Partido/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PARTIDO partido = db.PARTIDO.Find(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            return View(partido);
        }

        //
        // POST: /Partido/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PARTIDO partido = db.PARTIDO.Find(id);
            db.SP_PARTIDO_DELETE(partido.ID_PARTIDO);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}