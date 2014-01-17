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
    public class CloseCodeController : Controller
    {
        private TContext db = new TContext();

        //
        // GET: /CloseCode/

        public ViewResult Index()
        {
            return View(db.CloseCodes.ToList());
        }

        //
        // GET: /CloseCode/Details/5

        public ViewResult Details(int id)
        {
            CloseCode closecode = db.CloseCodes.Find(id);
            return View(closecode);
        }

        //
        // GET: /CloseCode/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /CloseCode/Create

        [HttpPost]
        public ActionResult Create(CloseCode closecode)
        {
            if (ModelState.IsValid)
            {
                db.CloseCodes.Add(closecode);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(closecode);
        }
        
        //
        // GET: /CloseCode/Edit/5
 
        public ActionResult Edit(int id)
        {
            CloseCode closecode = db.CloseCodes.Find(id);
            return View(closecode);
        }

        //
        // POST: /CloseCode/Edit/5

        [HttpPost]
        public ActionResult Edit(CloseCode closecode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(closecode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(closecode);
        }

        //
        // GET: /CloseCode/Delete/5
 
        public ActionResult Delete(int id)
        {
            CloseCode closecode = db.CloseCodes.Find(id);
            return View(closecode);
        }

        //
        // POST: /CloseCode/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            CloseCode closecode = db.CloseCodes.Find(id);
            db.CloseCodes.Remove(closecode);
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