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
    public class ResultadoController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Resultado/

        public ActionResult Index()
        {
            var resultado = db.RESULTADO.Include(r => r.PARTIDO);
            return View(resultado.ToList());
        }

        //
        // GET: /Resultado/Create

        public ActionResult Create()
        {
            ViewBag.ID_PARTIDO = new SelectList(db.PARTIDO, "ID_PARTIDO", "ID_PARTIDO");
            return View();
        }

        //
        // POST: /Resultado/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RESULTADO resultado)
        {
            if (ModelState.IsValid)
            {
                db.SP_RESULTADO_INSERT(resultado.ID_PARTIDO, resultado.PRIMERT_GOLES_EQUIPO1,
                    resultado.PRIMERT_GOLES_EQUIPO2,
                    resultado.SEGUNDOT_GOLES_EQUIPO1, resultado.SEGUNDOT_GOLES_EQUIPO2,
                    resultado.TIEMPOEXTRA_GOLES_EQUIPO1,
                    resultado.TIEMPOEXTRA_GOLES_EQUIPO2, resultado.PENALES_GOLES_EQUIPO1,
                    resultado.PENALES_GOLES_EQUIPO2,
                    resultado.TARJETAS_A_EQUIPO1, resultado.TARJETAS_A_EQUIPO2, resultado.TARJETAS_R_EQUIPO1,
                    resultado.TARJETAS_R_EQUIPO2);
                return RedirectToAction("Index");
            }

            ViewBag.ID_PARTIDO = new SelectList(db.PARTIDO, "ID_PARTIDO", "ID_PARTIDO", resultado.ID_PARTIDO);
            return View(resultado);
        }

        //
        // GET: /Resultado/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RESULTADO resultado = db.RESULTADO.Find(id);
            if (resultado == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PARTIDO = new SelectList(db.PARTIDO, "ID_PARTIDO", "ID_PARTIDO", resultado.ID_PARTIDO);
            return View(resultado);
        }

        //
        // POST: /Resultado/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RESULTADO resultado)
        {
            if (ModelState.IsValid)
            {
                db.SP_RESULTADO_UPDATE(resultado.ID_PARTIDO, resultado.PRIMERT_GOLES_EQUIPO1,
                    resultado.PRIMERT_GOLES_EQUIPO2,
                    resultado.SEGUNDOT_GOLES_EQUIPO1, resultado.SEGUNDOT_GOLES_EQUIPO2,
                    resultado.TIEMPOEXTRA_GOLES_EQUIPO1,
                    resultado.TIEMPOEXTRA_GOLES_EQUIPO2, resultado.PENALES_GOLES_EQUIPO1,
                    resultado.PENALES_GOLES_EQUIPO2,
                    resultado.TARJETAS_A_EQUIPO1, resultado.TARJETAS_A_EQUIPO2, resultado.TARJETAS_R_EQUIPO1,
                    resultado.TARJETAS_R_EQUIPO2, resultado.ID_RESULTADO);
                return RedirectToAction("Index");
            }
            ViewBag.ID_PARTIDO = new SelectList(db.PARTIDO, "ID_PARTIDO", "ID_PARTIDO", resultado.ID_PARTIDO);
            return View(resultado);
        }

        //
        // GET: /Resultado/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RESULTADO resultado = db.RESULTADO.Find(id);
            if (resultado == null)
            {
                return HttpNotFound();
            }
            return View(resultado);
        }

        //
        // POST: /Resultado/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RESULTADO resultado = db.RESULTADO.Find(id);
            db.SP_RESULTADO_DELETE(resultado.ID_RESULTADO);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}