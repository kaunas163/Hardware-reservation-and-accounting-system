using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HardwareReservationAndAccountingSystem.Models
{
    public class ReservationStatus
    {
        public byte Id { get; set; }

        [Required]
        public string Slug { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}