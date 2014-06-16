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
    public class CiudadController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Ciudad/

        public ActionResult Index()
        {
            var ciudad = db.CIUDAD.Include(c => c.PAIS);
            return View(ciudad.ToList());
        }

        //
        // GET: /Ciudad/Details/5

        public ActionResult Details(int id = 0)
        {
            CIUDAD ciudad = db.CIUDAD.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        //
        // GET: /Ciudad/Create

        public ActionResult Create()
        {
            ViewBag.ID_PAIS = new SelectList(db.PAIS, "ID_PAIS", "NOMBRE");
            return View();
        }

        //
        // POST: /Ciudad/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CIUDAD ciudad)
        {
            if (ModelState.IsValid)
            {
                db.CIUDAD.Add(ciudad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PAIS = new SelectList(db.PAIS, "ID_PAIS", "NOMBRE", ciudad.ID_PAIS);
            return View(ciudad);
        }

        //
        // GET: /Ciudad/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CIUDAD ciudad = db.CIUDAD.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PAIS = new SelectList(db.PAIS, "ID_PAIS", "NOMBRE", ciudad.ID_PAIS);
            return View(ciudad);
        }

        //
        // POST: /Ciudad/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CIUDAD ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PAIS = new SelectList(db.PAIS, "ID_PAIS", "NOMBRE", ciudad.ID_PAIS);
            return View(ciudad);
        }

        //
        // GET: /Ciudad/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CIUDAD ciudad = db.CIUDAD.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        //
        // POST: /Ciudad/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CIUDAD ciudad = db.CIUDAD.Find(id);
            db.CIUDAD.Remove(ciudad);
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