using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardwareReservationAndAccountingSystem.Models;

namespace HardwareReservationAndAccountingSystem.Controllers
{
    public class EquipmentsController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var equipments = _context.Equipments.ToList();
            return View(equipments);
        }

        [HttpPost]
        public ActionResult Save(Equipment equipment)
        {
            if (equipment.Id == 0)
            {
                _context.Equipments.Add(equipment);
            }
            else
            {
                var equipmentInDb = _context.Equipments.Single(x => x.Id == equipment.Id);
                equipmentInDb.Title = equipment.Title;
                equipmentInDb.Description = equipment.Description;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Equipments");
        }
    }
}