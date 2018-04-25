using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HardwareReservationAndAccountingSystem.Models
{
    public class EquipmentBundle
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public List<Equipment> Equipments { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}