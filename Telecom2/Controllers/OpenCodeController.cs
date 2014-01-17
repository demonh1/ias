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
    public class OpenCodeController : Controller
    {
        private TContext db = new TContext();

        //
        // GET: /OpenCode/

        public ViewResult Index()
        {
            return View(db.OpenCodes.ToList());
        }

        //
        // GET: /OpenCode/Details/5

        public ViewResult Details(int id)
        {
            OpenCode opencode = db.OpenCodes.Find(id);
            return View(opencode);
        }

        //
        // GET: /OpenCode/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /OpenCode/Create

        [HttpPost]
        public ActionResult Create(OpenCode opencode)
        {
            if (ModelState.IsValid)
            {
                db.OpenCodes.Add(opencode);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(opencode);
        }
        
        //
        // GET: /OpenCode/Edit/5
 
        public ActionResult Edit(int id)
        {
            OpenCode opencode = db.OpenCodes.Find(id);
            return View(opencode);
        }

        //
        // POST: /OpenCode/Edit/5

        [HttpPost]
        public ActionResult Edit(OpenCode opencode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opencode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opencode);
        }

        //
        // GET: /OpenCode/Delete/5
 
        public ActionResult Delete(int id)
        {
            OpenCode opencode = db.OpenCodes.Find(id);
            return View(opencode);
        }

        //
        // POST: /OpenCode/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            OpenCode opencode = db.OpenCodes.Find(id);
            db.OpenCodes.Remove(opencode);
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