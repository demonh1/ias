using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telecom2.Models;
using Telecom2.DAL;

namespace Telecom2.Controllers
{ 
    public class EngineerController : Controller
    {
        private TContext db = new TContext();

        //
        // GET: /Engineer/

        public ViewResult Index()
        {
            return View(db.Engineers.ToList());
        }

        //
        // GET: /Engineer/Details/5

        public ViewResult Details(int id)
        {
            Engineer engineer = db.Engineers.Find(id);
            return View(engineer);
        }

        //
        // GET: /Engineer/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Engineer/Create

        [HttpPost]
        public ActionResult Create(Engineer engineer)
        {
            if (ModelState.IsValid)
            {
                db.Engineers.Add(engineer);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(engineer);
        }
        
        //
        // GET: /Engineer/Edit/5
 
        public ActionResult Edit(int id)
        {
            Engineer engineer = db.Engineers.Find(id);
            return View(engineer);
        }

        //
        // POST: /Engineer/Edit/5

        [HttpPost]
        public ActionResult Edit(Engineer engineer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(engineer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(engineer);
        }

        //
        // GET: /Engineer/Delete/5
 
        public ActionResult Delete(int id)
        {
            Engineer engineer = db.Engineers.Find(id);
            return View(engineer);
        }

        //
        // POST: /Engineer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Engineer engineer = db.Engineers.Find(id);
            db.Engineers.Remove(engineer);
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