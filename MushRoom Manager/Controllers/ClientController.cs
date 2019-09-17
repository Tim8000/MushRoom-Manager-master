using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MushRoom_Manager.Models;
using MushRoom_Manager.ViewModels;

namespace MushRoom_Manager.Controllers
{
    public class ClientController : Controller
    {
        private ApplicationDbContext _context;

        public ClientController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Client
        public ActionResult Index()
        {
            var clients = _context.Clients;

            return View(clients);
        }

        public ActionResult Edit(int? Id)
        {
            try
            {
                var client = _context.Clients.SingleOrDefault(c => c.Id == Id);
                return View(client);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Edit method error", e);
            }
            

            
        }

        public ActionResult Save(Client client)
        {
            if (client.Id == 0)
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
                
            }
            else
            {
                var originalClient = _context.Clients.SingleOrDefault(c => c.Id == client.Id);

                originalClient.Name = client.Name;
                originalClient.Phone = client.Phone;

                _context.SaveChanges();
                
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var clientToDelete = _context.Clients.SingleOrDefault(c => c.Id == id);

                _context.Clients.Remove(clientToDelete);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Delete method error", e);
            }

            
            
        }


        public ActionResult Create()
        {
          return View("Create");
        }
    }
}