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
                Reservation = new Reservation(),
                Reservations = _context.Reservations.ToList(),
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
            reservation.ReservationStatusId = (byte)(User.IsInRole("admin") ? 2 : 1);
            reservation.EquipmentBundle = bundle;
            reservation.UserId = User.Identity.GetUserId();

            //var notification = new Notification
            //{
            //    Topic = "Rezervacija sukurta",
            //    Description = "Rezervacija įrangos komplektui \"" + bundle.Title + "\" sėkmingai sukurta.",
            //    CreatedOn = DateTime.Now,
            //    IsRead = false,
            //    IsArchived = false,
            //    ReservationId = reservation.Id
            //};

            //reservation.Notifications.Add(notification);

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