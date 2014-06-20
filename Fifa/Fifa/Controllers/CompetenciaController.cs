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
    public class CompetenciaController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Competencia/

        public ActionResult Index()
        {
            return View(db.COMPETENCIA.ToList());
        }


        //
        // GET: /Competencia/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Competencia/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(COMPETENCIA competencia)
        {
            if (ModelState.IsValid)
            {
                db.SP_COMPETENCIA_INSERT(competencia.NOMBRE, competencia.FECHA_INICIO, competencia.FECHA_FIN,
                    competencia.ESTADO_ACTUAL);
                return RedirectToAction("Index");
            }

            return View(competencia);
        }

        //
        // GET: /Competencia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            COMPETENCIA competencia = db.COMPETENCIA.Find(id);
            if (competencia == null)
            {
                return HttpNotFound();
            }
            return View(competencia);
        }

        //
        // POST: /Competencia/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(COMPETENCIA competencia)
        {
            if (ModelState.IsValid)
            {
                db.SP_COMPETENCIA_UPDATE(competencia.NOMBRE, competencia.FECHA_INICIO, competencia.FECHA_FIN,
                    competencia.ESTADO_ACTUAL, competencia.ID_COMPETENCIA);
                return RedirectToAction("Index");
            }
            return View(competencia);
        }

        //
        // GET: /Competencia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            COMPETENCIA competencia = db.COMPETENCIA.Find(id);
            if (competencia == null)
            {
                return HttpNotFound();
            }
            return View(competencia);
        }

        //
        // POST: /Competencia/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COMPETENCIA competencia = db.COMPETENCIA.Find(id);
            db.SP_COMPETENCIA_DELETE(competencia.ID_COMPETENCIA);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}