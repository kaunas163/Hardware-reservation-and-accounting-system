using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using HardwareReservationAndAccountingSystem.Models;
using HardwareReservationAndAccountingSystem.ViewModels;

namespace HardwareReservationAndAccountingSystem.Controllers
{
    [Authorize]
    public class EquipmentsController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var equipments = _context.Equipments.OrderBy(x => x.Title).ToList();
            var types = _context.EquipmentTypes.ToList();
            var viewModel = new EquipmentsMain
            {
                Equipments = equipments,
                EquipmentTypes = types
            };
            return View(viewModel);
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
                equipmentInDb.EquipmentTypeId = equipment.EquipmentTypeId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Equipments");
        }
    }
}