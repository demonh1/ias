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
    public class ClientController : Controller
    {
    
        private IClientRepository clientRepository;

        // ctor
        public ClientController() { this.clientRepository = new ClientRepository(new TContext()); }
        public ClientController(IClientRepository clientRepository) { this.clientRepository = clientRepository; }


        //
        // GET: /Client/

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name desc" : "";
            ViewBag.DateSortParm = sortOrder == "Phone" ? "Phone desc" : "Phone";

            if (Request.HttpMethod == "GET") searchString = currentFilter;
            else page = 1;

            ViewBag.CurrentFilter = searchString;

            var clients = from s in clientRepository.getClients() select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                clients = clients.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper())
                    || s.FirstMidName.ToUpper().Contains(searchString.ToUpper())
                    || s.SecondName.ToUpper().Contains(searchString.ToUpper())
                    || s.Phone.Contains(searchString) );

            }

            switch (sortOrder)
            {
                case "Name desc":
                    clients = clients.OrderByDescending(s => s.LastName);
                    break;
                case "Phone":
                    clients = clients.OrderBy(s => s.Phone);
                    break;
                case "Phone desc": clients = clients.OrderByDescending(s => s.Phone);
                    break;
                default:
                    clients = clients.OrderBy(s => s.LastName); break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(clients.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Client/Details/5

        public ViewResult Details(int id)
        {
            Client client = clientRepository.getClientById(id);
            return View(client);
        }

        //
        // GET: /Client/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Client/Create

        [HttpPost]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
               
                clientRepository.insertClient(client);
                clientRepository.save();

                return RedirectToAction("Index");  
            }

            return View(client);
        }
        
        //
        // GET: /Client/Edit/5
 
        public ActionResult Edit(int id)
        {
            Client client = clientRepository.getClientById(id);
            return View(client);
        }

        //
        // POST: /Client/Edit/5

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                clientRepository.updateClient(client);
                clientRepository.save();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        //
        // GET: /Client/Delete/5
 
        public ActionResult Delete(int id)
        {
            Client client = clientRepository.getClientById(id);
            return View(client);
        }

        //
        // POST: /Client/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = clientRepository.getClientById(id);
       
            clientRepository.deleteClient(id);
            clientRepository.save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            clientRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}