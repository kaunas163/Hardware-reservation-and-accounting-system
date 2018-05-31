using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardwareReservationAndAccountingSystem.Models;
using HardwareReservationAndAccountingSystem.ViewModels;
using Microsoft.AspNet.Identity;

namespace HardwareReservationAndAccountingSystem.Controllers
{
    [Authorize]
    public class RezervationsController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var bundles = _context.EquipmentBundles.OrderBy(x => x.Title).ToList();

            var viewModel = new ReservationPage
            {
                EquipmentBundles = bundles,
                Reservation = new Reservation()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Reservation reservation)
        {
            var bundleId = Convert.ToInt32(Request.Form["equipmentBundles"]);
            var bundle = _context.EquipmentBundles.Single(x => x.Id == bundleId);

            reservation.CreatedOn = DateTime.Now;
            reservation.UpdatedOn = DateTime.Now;
            if (User.IsInRole("admin"))
            {
                reservation.ReservationStatusId = 2;
            }
            else
            {
                reservation.ReservationStatusId = 1;
            }
            reservation.EquipmentBundle = bundle;
            reservation.UserId = User.Identity.GetUserId();

            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details()
        {
            return View();
        }
    }
}