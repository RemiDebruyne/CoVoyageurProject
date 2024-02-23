using CoVoyageurCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoVoyageurCore.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } 
        public int RideId { get; set; }
        public Ride Ride { get; set; }
        public DateTime ReservationDate { get; set; }
        public ReservationStatus Status { get; set; }

        public enum ReservationStatus
        {
            Confirmed,
            Cancelled,
            Waiting
        }
    }
}
