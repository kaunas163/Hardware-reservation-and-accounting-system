using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardwareReservationAndAccountingSystem.Models;

namespace HardwareReservationAndAccountingSystem.ViewModels
{
    public class EquipmentsMain
    {
        public IEnumerable<Equipment> Equipments { get; set; }
        public IEnumerable<EquipmentType> EquipmentTypes { get; set; }
    }
}