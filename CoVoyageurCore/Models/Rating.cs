using CoVoyageurCore.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoVoyageurCore.Models
{
    [Table("rating")]
    public class Rating
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("rideid")]
        public int RideId { get; set; }

        [Column("ratinguserid")]
        public int RatingUserId { get; set; }

        [Column("rateduserid")]
        public int RatedUserId { get; set; }

        [Column("score")]
        public decimal Score { get; set; }

        [Column("comment")]
        public string? Comment { get; set; }

        [Column("ratingdate")]
        public DateTime RatingDate { get; set; }

        public User RatingUser { get; set; }
        public User RatedUser { get; set; }
        public Ride Ride { get; set; }

    }
}