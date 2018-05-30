using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardwareReservationAndAccountingSystem.Models;
using HardwareReservationAndAccountingSystem.ViewModels;
using WebGrease.Css.Extensions;

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
                equipmentInDb.Title = equipmentBundle.Title.Trim();
                equipmentInDb.Description = equipmentBundle.Description.Trim();
            }

            _context.SaveChanges();
            return RedirectToAction("Details", new { id = equipmentBundle.Id });
        }

        public ActionResult Details(int id)
        {
            var bundle = _context.EquipmentBundles.Include(x => x.Equipments).SingleOrDefault(x => x.Id == id);
            var availableEquipments = _context.Equipments
                .Where(x => x.IsAvailable)
                .OrderBy(x => x.Title)
                .ToList();

            if (bundle == null)
            {
                return HttpNotFound();
            }

            foreach (var bundleEquipment in bundle.Equipments)
            {
                availableEquipments.Remove(bundleEquipment);
            }

            var viewModel = new EquipmentBundleDetails
            {
                EquipmentBundle = bundle,
                Equipments = availableEquipments,
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult AddEquipmentToBundle(EquipmentBundle equipmentBundle)
        {
            var unpreparedEquipmentIds = Request.Form["equipmentListItems"];
            var equipmentIds = unpreparedEquipmentIds.Split(',').Select(x => Convert.ToInt32(x)).ToList();
            var equipmentBundleInDb = _context.EquipmentBundles.Include("Equipments").Single(x => x.Id == equipmentBundle.Id);
            if (equipmentBundleInDb == null)
            {
                return HttpNotFound();
            }

            foreach (var equipmentId in equipmentIds)
            {
                var equipment = _context.Equipments.Single(x => x.Id == equipmentId);
                if (equipment == null)
                {
                    return HttpNotFound();
                }
                equipmentBundleInDb.Equipments.Add(equipment);
            }

            _context.SaveChanges();
            return RedirectToAction("Details", new {id = equipmentBundle.Id});
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult RemoveEquipment()
        {
            var equipmentId = Convert.ToInt32(Request.Form["EquipmentId"]);
            var equipmentBundleId = Convert.ToInt32(Request.Form["EquipmentBundleId"]);

            var bundleInDb = _context.EquipmentBundles.Include("Equipments").Single(x => x.Id == equipmentBundleId);
            var equipment = _context.Equipments.Single(x => x.Id == equipmentId);

            if (bundleInDb == null || equipment == null)
            {
                return HttpNotFound();
            }

            bundleInDb.Equipments.Remove(equipment);
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = equipmentBundleId });
        }
    }
}