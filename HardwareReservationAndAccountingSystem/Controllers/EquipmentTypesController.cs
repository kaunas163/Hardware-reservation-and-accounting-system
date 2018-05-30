using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardwareReservationAndAccountingSystem.Models;

namespace HardwareReservationAndAccountingSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class EquipmentTypesController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var types = _context.EquipmentTypes.OrderBy(x => x.Title).ToList();
            return View(types);
        }

        [HttpPost]
        public ActionResult Save(EquipmentType type)
        {
            if (type.Id == 0)
            {
                _context.EquipmentTypes.Add(type);
            }
            else
            {
                var typeInDb = _context.EquipmentTypes.Single(x => x.Id == type.Id);
                typeInDb.Title = type.Title.Trim();
                typeInDb.Color = type.Color.Trim();
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "EquipmentTypes");
        }
    }
}