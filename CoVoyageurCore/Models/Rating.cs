using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoVoyageurCore.Models
{
    [Table("rating")]
    public class Rating
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("rideid")]
        [ForeignKey("Ride")]
        public int RideId { get; set; }
        public virtual Ride Ride { get; set; }

        [Column("userid")]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Column("ratinguserid")]
        [ForeignKey("RatingUser")]
        public int RatingUserId { get; set; }
        public virtual User RatingUser { get; set; }

        [Column("rateduserid")]
        [ForeignKey("RatedUser")]
        public int RatedUserId { get; set; }
        public virtual User RatedUser { get; set; }

        [Column("score")]
        public int Score { get; set; }

        [Column("comment")]
        public string? Comment { get; set; }

        [Column("ratingdate")]
        public DateTime RatingDate { get; set; }
    }
}
