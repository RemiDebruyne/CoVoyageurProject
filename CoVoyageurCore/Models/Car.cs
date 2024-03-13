using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoVoyageurCore.Models
{
    [Table("car")]
    public class Car
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("license_plate")]
        [Required]
        public string? LicensePlate { get; set; }

        [Column("model")]
        [Required]
        public string? Model { get; set; }

        [Column("brand")]
        [Required]
        public string? Brand { get; set; }

        [Column("userId")]
        [Required]
        public int UserId { get; set; }
       
        [Column("color")]
        [Required]
        public CarColor Color { get; set; }

        public enum CarColor
        {
            Nothing,
            White,
            Black,
            Red,
            Green,
            Blue,
            Yellow,
            Pink,
            Purple
        }

        public User User { get; set; }
    }
}
