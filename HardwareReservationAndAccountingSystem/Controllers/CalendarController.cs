﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HardwareReservationAndAccountingSystem.Controllers
{
    [Authorize]
    public class CalendarController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}