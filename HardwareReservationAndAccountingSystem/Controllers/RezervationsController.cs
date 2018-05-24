using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardwareReservationAndAccountingSystem.Models;

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
            return View();
        }

        public ActionResult Save()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }
    }
}