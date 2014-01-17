using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telecom2.Models;
using Telecom2.DAL;
using PagedList;

namespace Telecom2.Controllers
{ 
    public class RequestController : Controller
    {
        private TContext db = new TContext();

        //
        // GET: /Request/

        public ViewResult Index(string currentFilter, string searchString, int? page)
        {
            var requests = db.Requests.Include(r => r.Operator).Include(r => r.Client).Include(r => r.Engineer).Include(r => r.OpenCode).Include(r => r.DamageCode).Include(r => r.CloseCode).ToList();

            if (Request.HttpMethod == "GET") searchString = currentFilter;
            else page = 1;

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                requests = requests.Where(r => r.DamageCode.FCDamage.Contains(searchString) 
                    || r.CloseCode.FCClose.Contains(searchString) 
                    || r.Engineer.LastName.Contains(searchString)
                    || r.Operator.LastName.Contains(searchString)
                    || r.Client.Phone.Contains(searchString)).ToList();

            }

            int pageNumber = page ?? 1;
            int pageSize = 7;
            return View(requests.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Request/Details/5

        public ViewResult Details(int id)
        {
            Request request = db.Requests.Find(id);
            return View(request);
        }

        //
        // GET: /Request/Create

        public ActionResult Create(string searchString)
        {
            ViewBag.CurrentFilter = searchString;

            ViewBag.OperatorID = new SelectList(db.Operators, "OperatorID", "LastName");
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "Phone");
            ViewBag.EngineerID = new SelectList(db.Engineers, "EngineerID", "FullRegion");
            ViewBag.OpenCodeID = new SelectList(db.OpenCodes, "OpenCodeID", "FCOpen");
            ViewBag.DamageCodeID = new SelectList(db.DamageCodes, "DamageCodeID", "FCDamage");
            ViewBag.CloseCodeID = new SelectList(db.CloseCodes, "CloseCodeID", "FCClose");
            return View();
        } 

        //
        // POST: /Request/Create

        [HttpPost]
        public ActionResult Create(Request request)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.OperatorID = new SelectList(db.Operators, "OperatorID", "LastName", request.OperatorID);
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "Phone", request.ClientID);
            ViewBag.EngineerID = new SelectList(db.Engineers, "EngineerID", "FullRegion", request.EngineerID);
            ViewBag.OpenCodeID = new SelectList(db.OpenCodes, "OpenCodeID", "FCOpen", request.OpenCodeID);
            ViewBag.DamageCodeID = new SelectList(db.DamageCodes, "DamageCodeID", "FCDamage", request.DamageCodeID);
            ViewBag.CloseCodeID = new SelectList(db.CloseCodes, "CloseCodeID", "FCClose", request.CloseCodeID);
            return View(request);
        }
        
        //
        // GET: /Request/Edit/5
 
        public ActionResult Edit(int id)
        {
            Request request = db.Requests.Find(id);
            ViewBag.OperatorID = new SelectList(db.Operators, "OperatorID", "LastName", request.OperatorID);
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "Phone", request.ClientID);
            ViewBag.EngineerID = new SelectList(db.Engineers, "EngineerID", "LastName", request.EngineerID);
            ViewBag.OpenCodeID = new SelectList(db.OpenCodes, "OpenCodeID", "FCOpen", request.OpenCodeID);
            ViewBag.DamageCodeID = new SelectList(db.DamageCodes, "DamageCodeID", "FCDamage", request.DamageCodeID);
            ViewBag.CloseCodeID = new SelectList(db.CloseCodes, "CloseCodeID", "FCClose", request.CloseCodeID);
            return View(request);
        }

        //
        // POST: /Request/Edit/5

        [HttpPost]
        public ActionResult Edit(Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OperatorID = new SelectList(db.Operators, "OperatorID", "LastName", request.OperatorID);
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "LastName", request.ClientID);
            ViewBag.EngineerID = new SelectList(db.Engineers, "EngineerID", "LastName", request.EngineerID);
            ViewBag.OpenCodeID = new SelectList(db.OpenCodes, "OpenCodeID", "OpenCodeID", request.OpenCodeID);
            ViewBag.DamageCodeID = new SelectList(db.DamageCodes, "DamageCodeID", "DamageCodeID", request.DamageCodeID);
            ViewBag.CloseCodeID = new SelectList(db.CloseCodes, "CloseCodeID", "CloseCodeID", request.CloseCodeID);
            return View(request);
        }

        //
        // GET: /Request/Delete/5
 
        public ActionResult Delete(int id)
        {
            Request request = db.Requests.Find(id);
            return View(request);
        }

        //
        // POST: /Request/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
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