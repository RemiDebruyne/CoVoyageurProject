using CoVoyageurCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoVoyageurCore.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int RideId { get; set; }
        public Ride Ride { get; set; }
        public int RatedUserId { get; set; }
        public User RatedUser { get; set; }
        public int RatingUserId { get; set; }
        public User RatingUser { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public DateTime RatingDate { get; set; }
    }
}
