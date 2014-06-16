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
    public class DesempenioDMDController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /DesempenioDMD/

        public ActionResult Index()
        {
            var desempenio_dmd = db.DESEMPENIO_DMD.Include(d => d.RESULTADO).Include(d => d.JUGADOR);
            return View(desempenio_dmd.ToList());
        }

        //
        // GET: /DesempenioDMD/Details/5

        public ActionResult Details(int id = 0)
        {
            DESEMPENIO_DMD desempenio_dmd = db.DESEMPENIO_DMD.Find(id);
            if (desempenio_dmd == null)
            {
                return HttpNotFound();
            }
            return View(desempenio_dmd);
        }

        //
        // GET: /DesempenioDMD/Create

        public ActionResult Create()
        {
            ViewBag.ID_RESULTADO = new SelectList(db.RESULTADO, "ID_RESULTADO", "ID_RESULTADO");
            ViewBag.ID_JUGADOR = new SelectList(db.JUGADOR, "ID_JUGADOR", "NOMBRE");
            return View();
        }

        //
        // POST: /DesempenioDMD/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DESEMPENIO_DMD desempenio_dmd)
        {
            if (ModelState.IsValid)
            {
                db.DESEMPENIO_DMD.Add(desempenio_dmd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_RESULTADO = new SelectList(db.RESULTADO, "ID_RESULTADO", "ID_RESULTADO", desempenio_dmd.ID_RESULTADO);
            ViewBag.ID_JUGADOR = new SelectList(db.JUGADOR, "ID_JUGADOR", "NOMBRE", desempenio_dmd.ID_JUGADOR);
            return View(desempenio_dmd);
        }

        //
        // GET: /DesempenioDMD/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DESEMPENIO_DMD desempenio_dmd = db.DESEMPENIO_DMD.Find(id);
            if (desempenio_dmd == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_RESULTADO = new SelectList(db.RESULTADO, "ID_RESULTADO", "ID_RESULTADO", desempenio_dmd.ID_RESULTADO);
            ViewBag.ID_JUGADOR = new SelectList(db.JUGADOR, "ID_JUGADOR", "NOMBRE", desempenio_dmd.ID_JUGADOR);
            return View(desempenio_dmd);
        }

        //
        // POST: /DesempenioDMD/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DESEMPENIO_DMD desempenio_dmd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(desempenio_dmd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_RESULTADO = new SelectList(db.RESULTADO, "ID_RESULTADO", "ID_RESULTADO", desempenio_dmd.ID_RESULTADO);
            ViewBag.ID_JUGADOR = new SelectList(db.JUGADOR, "ID_JUGADOR", "NOMBRE", desempenio_dmd.ID_JUGADOR);
            return View(desempenio_dmd);
        }

        //
        // GET: /DesempenioDMD/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DESEMPENIO_DMD desempenio_dmd = db.DESEMPENIO_DMD.Find(id);
            if (desempenio_dmd == null)
            {
                return HttpNotFound();
            }
            return View(desempenio_dmd);
        }

        //
        // POST: /DesempenioDMD/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DESEMPENIO_DMD desempenio_dmd = db.DESEMPENIO_DMD.Find(id);
            db.DESEMPENIO_DMD.Remove(desempenio_dmd);
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