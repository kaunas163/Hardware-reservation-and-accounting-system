using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardwareReservationAndAccountingSystem.Models;

namespace HardwareReservationAndAccountingSystem.ViewModels
{
    public class RemoveEquipmentFromBundle
    {
        public EquipmentBundle EquipmentBundle { get; set; }
        public Equipment Equipment { get; set; }
    }
}