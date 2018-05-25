using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardwareReservationAndAccountingSystem.Models;

namespace HardwareReservationAndAccountingSystem.Controllers
{
    [Authorize]
    public class EquipmentBundlesController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var bundles = _context.EquipmentBundles.OrderBy(x => x.Title).ToList();
            return View(bundles);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Save(EquipmentBundle equipmentBundle)
        {
            if (equipmentBundle.Id == 0)
            {
                _context.EquipmentBundles.Add(equipmentBundle);
            }
            else
            {
                var equipmentInDb = _context.EquipmentBundles.Single(x => x.Id == equipmentBundle.Id);
                equipmentInDb.Title = equipmentBundle.Title;
                equipmentInDb.Description = equipmentBundle.Description;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "EquipmentBundles");
        }

        public ActionResult Details(int id)
        {
            var bundle = _context.EquipmentBundles.Include(x => x.Equipments).SingleOrDefault(x => x.Id == id);

            if (bundle == null)
            {
                return HttpNotFound();
            }

            return View(bundle);
        }
    }
}