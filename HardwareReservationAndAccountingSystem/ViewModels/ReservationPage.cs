using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardwareReservationAndAccountingSystem.Models;

namespace HardwareReservationAndAccountingSystem.ViewModels
{
    public class ReservationPage
    {
        public List<EquipmentBundle> EquipmentBundles { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Reservation Reservation { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}