using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HardwareReservationAndAccountingSystem.Models
{
    public class EquipmentType
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Pavadinimas")]
        [MaxLength(50)]
        public string Title { get; set; }

        [Display(Name = "Spalva")]
        public string Color { get; set; }
    }
}