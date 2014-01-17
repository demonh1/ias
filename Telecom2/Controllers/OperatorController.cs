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
    public class OperatorController : Controller
    {
        private TContext db = new TContext();

        //
        // GET: /Operator/

        public ViewResult Index()
        {
            return View(db.Operators.ToList());
        }

        //
        // GET: /Operator/Details/5

        public ViewResult Details(int id)
        {
            Operator op = db.Operators.Find(id);
            return View(op);
        }

        //
        // GET: /Operator/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Operator/Create

        [HttpPost]
        public ActionResult Create(Operator op)
        {
            if (ModelState.IsValid)
            {
                db.Operators.Add(op);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(op);
        }
        
        //
        // GET: /Operator/Edit/5
 
        public ActionResult Edit(int id)
        {
            Operator op = db.Operators.Find(id);
            return View(op);
        }

        //
        // POST: /Operator/Edit/5

        [HttpPost]
        public ActionResult Edit(Operator op)
        {
            if (ModelState.IsValid)
            {
                db.Entry(op).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(op);
        }

        //
        // GET: /Operator/Delete/5
 
        public ActionResult Delete(int id)
        {
            Operator op = db.Operators.Find(id);
            return View(op);
        }

        //
        // POST: /Operator/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Operator op = db.Operators.Find(id);
            db.Operators.Remove(op);
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