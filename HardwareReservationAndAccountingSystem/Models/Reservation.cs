using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HardwareReservationAndAccountingSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Display(Name = "Rezervacija nuo")]
        public DateTime ReservedFrom { get; set; }

        [Display(Name = "Rezervacija iki")]
        public DateTime ReservedTo { get; set; }

        [Display(Name = "Sukurta")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Atnaujinta")]
        public DateTime UpdatedOn { get; set; }

        [Display(Name = "Rezervacijos statusas")]
        public ReservationStatus ReservationStatus { get; set; }
        public byte ReservationStatusId { get; set; }

        [Display(Name = "Įrangos komplektas")]
        public EquipmentBundle EquipmentBundle { get; set; }
        public int EquipmentBundleId { get; set; }

        [Display(Name = "Pranešimai")]
        public List<Notification> Notifications { get; set; }

        [Display(Name = "Vartotojas")]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}