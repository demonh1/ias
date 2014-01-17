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
    public class DamageCodeController : Controller
    {
        private TContext db = new TContext();

        //
        // GET: /Damage/

        public ViewResult Index()
        {
            return View(db.DamageCodes.ToList());
        }

        //
        // GET: /Damage/Details/5

        public ViewResult Details(int id)
        {
            DamageCode damagecode = db.DamageCodes.Find(id);
            return View(damagecode);
        }

        //
        // GET: /Damage/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Damage/Create

        [HttpPost]
        public ActionResult Create(DamageCode damagecode)
        {
            if (ModelState.IsValid)
            {
                db.DamageCodes.Add(damagecode);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(damagecode);
        }
        
        //
        // GET: /Damage/Edit/5
 
        public ActionResult Edit(int id)
        {
            DamageCode damagecode = db.DamageCodes.Find(id);
            return View(damagecode);
        }

        //
        // POST: /Damage/Edit/5

        [HttpPost]
        public ActionResult Edit(DamageCode damagecode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(damagecode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(damagecode);
        }

        //
        // GET: /Damage/Delete/5
 
        public ActionResult Delete(int id)
        {
            DamageCode damagecode = db.DamageCodes.Find(id);
            return View(damagecode);
        }

        //
        // POST: /Damage/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            DamageCode damagecode = db.DamageCodes.Find(id);
            db.DamageCodes.Remove(damagecode);
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