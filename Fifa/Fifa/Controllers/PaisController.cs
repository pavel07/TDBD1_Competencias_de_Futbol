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
    public class PaisController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Pais/

        public ActionResult Index()
        {
            return View(db.PAIS.ToList());
        }

        //
        // GET: /Pais/Details/5

        public ActionResult Details(int id = 0)
        {
            PAIS pais = db.PAIS.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        //
        // GET: /Pais/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pais/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PAIS pais)
        {
            if (ModelState.IsValid)
            {
                db.PAIS.Add(pais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pais);
        }

        //
        // GET: /Pais/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PAIS pais = db.PAIS.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        //
        // POST: /Pais/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PAIS pais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pais);
        }

        //
        // GET: /Pais/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PAIS pais = db.PAIS.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        //
        // POST: /Pais/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PAIS pais = db.PAIS.Find(id);
            db.PAIS.Remove(pais);
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