using CoVoyageurCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoVoyageurCore.Models
{
    public class Ride
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RideDate { get; set; }
        public decimal Price { get; set; }
        public int AvailableSeats { get; set; }
        public List<User> UserList { get; set; }
        public int UserId { get; set; } 
        public User User { get; set; }
    }
}
