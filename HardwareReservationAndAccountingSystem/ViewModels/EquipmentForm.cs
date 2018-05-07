using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardwareReservationAndAccountingSystem.Models;

namespace HardwareReservationAndAccountingSystem.ViewModels
{
    public class EquipmentForm
    {
        public Equipment Equipment { get; set; }
        public IEnumerable<EquipmentType> EquipmentTypes { get; set; }
    }
}