using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardwareReservationAndAccountingSystem.Models;

namespace HardwareReservationAndAccountingSystem.ViewModels
{
    public class EquipmentBundleDetails
    {
        public EquipmentBundle EquipmentBundle { get; set; }
        public List<Equipment> Equipments { get; set; }
        public Reservation Reservation { get; set; }
    }
}