using CoVoyageurCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoVoyageurCore.Models
{
    [Table("ride")]
    public class Ride
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("creationDate")]
        public DateTime CreationDate { get; set; }

        [Column("rideDate")]
        public DateTime RideDate { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("availableSeats")]
        public int AvailableSeats { get; set; }

        [Column("departure")]
        public string Departure { get; set; }

        [Column("arrival")]
        public string Arrival { get; set; }

        public int UserId { get; set; } 
        public User User { get; set; }

       
    }
}
