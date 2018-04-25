using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HardwareReservationAndAccountingSystem.Models
{
    public class Notification
    {
        public int Id { get; set; }

        [Required]
        public string Topic { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsRead { get; set; }

        public bool IsArchived { get; set; }

        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}