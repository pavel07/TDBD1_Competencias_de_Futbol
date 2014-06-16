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
    public class EquipoCompetenciaController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /EquipoCompetencia/

        public ActionResult Index()
        {
            var equipo_competencia = db.EQUIPO_COMPETENCIA.Include(e => e.COMPETENCIA).Include(e => e.EQUIPO);
            return View(equipo_competencia.ToList());
        }

        //
        // GET: /EquipoCompetencia/Details/5

        public ActionResult Details(int id = 0)
        {
            EQUIPO_COMPETENCIA equipo_competencia = db.EQUIPO_COMPETENCIA.Find(id);
            if (equipo_competencia == null)
            {
                return HttpNotFound();
            }
            return View(equipo_competencia);
        }

        //
        // GET: /EquipoCompetencia/Create

        public ActionResult Create()
        {
            ViewBag.ID_COMPETENCIA = new SelectList(db.COMPETENCIA, "ID_COMPETENCIA", "NOMBRE");
            ViewBag.ID_EQUIPO = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBRE");
            return View();
        }

        //
        // POST: /EquipoCompetencia/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EQUIPO_COMPETENCIA equipo_competencia)
        {
            if (ModelState.IsValid)
            {
                db.EQUIPO_COMPETENCIA.Add(equipo_competencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_COMPETENCIA = new SelectList(db.COMPETENCIA, "ID_COMPETENCIA", "NOMBRE", equipo_competencia.ID_COMPETENCIA);
            ViewBag.ID_EQUIPO = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBRE", equipo_competencia.ID_EQUIPO);
            return View(equipo_competencia);
        }

        //
        // GET: /EquipoCompetencia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EQUIPO_COMPETENCIA equipo_competencia = db.EQUIPO_COMPETENCIA.Find(id);
            if (equipo_competencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_COMPETENCIA = new SelectList(db.COMPETENCIA, "ID_COMPETENCIA", "NOMBRE", equipo_competencia.ID_COMPETENCIA);
            ViewBag.ID_EQUIPO = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBRE", equipo_competencia.ID_EQUIPO);
            return View(equipo_competencia);
        }

        //
        // POST: /EquipoCompetencia/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EQUIPO_COMPETENCIA equipo_competencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipo_competencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_COMPETENCIA = new SelectList(db.COMPETENCIA, "ID_COMPETENCIA", "NOMBRE", equipo_competencia.ID_COMPETENCIA);
            ViewBag.ID_EQUIPO = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBRE", equipo_competencia.ID_EQUIPO);
            return View(equipo_competencia);
        }

        //
        // GET: /EquipoCompetencia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EQUIPO_COMPETENCIA equipo_competencia = db.EQUIPO_COMPETENCIA.Find(id);
            if (equipo_competencia == null)
            {
                return HttpNotFound();
            }
            return View(equipo_competencia);
        }

        //
        // POST: /EquipoCompetencia/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EQUIPO_COMPETENCIA equipo_competencia = db.EQUIPO_COMPETENCIA.Find(id);
            db.EQUIPO_COMPETENCIA.Remove(equipo_competencia);
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