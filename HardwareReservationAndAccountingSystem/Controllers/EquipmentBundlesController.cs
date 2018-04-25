using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardwareReservationAndAccountingSystem.Models;

namespace HardwareReservationAndAccountingSystem.Controllers
{
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
    }
}