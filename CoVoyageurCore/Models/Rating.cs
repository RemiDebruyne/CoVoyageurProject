using CoVoyageurCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoVoyageurCore.Models
{
    [Table("rating")]
    public class Rating
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("rideid")]
        public int RideId { get; set; }

        [Column("ratingUserId")]
        public int RatingUserId { get; set; }

        [Column("ratedUserId")]
        public int RatedUserId { get; set; }

        [Column("score")]
        public int Score { get; set; }

        [Column("comment")]
        public string? Comment { get; set; }

        [Column("ratingDate")]
        public DateTime RatingDate { get; set; }


        public Ride Ride { get; set; }      
        public User RatedUser { get; set; }
        public User RatingUser { get; set; }

        
    
       
    }
}
