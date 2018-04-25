using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardwareReservationAndAccountingSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public DateTime ReservedFrom { get; set; }

        public DateTime ReservedTo { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public byte ReservationStatusId { get; set; }
        public ReservationStatus ReservationStatus { get; set; }

        public int EquipmentBundleId { get; set; }
        public EquipmentBundle EquipmentBundle { get; set; }

        public List<Notification> Notifications { get; set; }
    }
}