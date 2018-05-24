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
        [Display(Name = "Pavadinimas")]
        public string Title { get; set; }

        [Display(Name = "Aprašymas")]
        public string Description { get; set; }

        public List<Equipment> Equipments { get; set; }

        public List<Reservation> Reservations { get; set; }

        [Display(Name = "Viešai paskelbtas ir leidžiamas rezervuoti?")]
        public bool IsAvailable { get; set; }
    }
}