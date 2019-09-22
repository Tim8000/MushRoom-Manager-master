using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MushRoom_Manager.Models;
using MushRoom_Manager.ViewModels;
namespace MushRoom_Manager.Controllers
{
    public class MushroomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        
        public MushroomsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New(int? Id)
        {
            if (Id == 0)
            {
                return View("New");
            }
            var mushroom = _context.MushroomTypes.SingleOrDefault(m => m.Id == Id);
            return View(mushroom);
            
        }

        // GET: MushroomTypes

       // [Route("MushroomTypes/New")]
        public ActionResult MushroomTypes()
        {
           
            var mushroomTypes = _context.MushroomTypes.ToList();
            
           
            return View(mushroomTypes);
          // return Content(Id.ToString());
        }

        [HttpPost]
        public ActionResult Save(MushroomType mushroomtype)
        {
            var randomId = new Random();  // Solved problem with null ID's, will change it later.

            if (mushroomtype.Id == null)
            {
                mushroomtype.Id =Convert.ToByte(randomId.Next(20, 100));
                _context.MushroomTypes.Add(mushroomtype);
                _context.SaveChanges();
            }
            else
            {
                var mush = _context.MushroomTypes.SingleOrDefault(m => m.Id == mushroomtype.Id);
                mush.Name = mushroomtype.Name;
                mush.PackageWeight = mushroomtype.PackageWeight;

                _context.SaveChanges();
            }

            return RedirectToAction("MushroomTypes");
        }



        public ActionResult Edit(int id)
        {
            var mushroom = _context.MushroomTypes.SingleOrDefault(m => m.Id == id);
            return View(mushroom);
        }

        public ActionResult Delete(int id)
        {
            var mushToDelete = _context.MushroomTypes.SingleOrDefault(m => m.Id == id);
            _context.MushroomTypes.Remove(mushToDelete);
            _context.SaveChanges();

            return RedirectToAction("MushroomTypes");
        } 

       
    }
}