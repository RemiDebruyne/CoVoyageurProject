using System.ComponentModel.DataAnnotations.Schema;

namespace CoVoyageurCore.Models
{
    [Table("reservation")]
    public class Reservation
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("userId")]
        public int UserId { get; set; }

        [Column("rideId")]
        public int RideId { get; set; }

        [Column("ride")]
        public Ride Ride { get; set; }

        [Column("reservationDate")]
        public DateTime ReservationDate { get; set; }

        [Column("status")]
        public ReservationStatus Status { get; set; }
      
        public enum ReservationStatus
        {
            Confirmed,
            Cancelled,
            Waiting
        }

        public User User { get; set; }
    }
}
