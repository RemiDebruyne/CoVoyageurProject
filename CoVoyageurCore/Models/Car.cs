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
        public string? LicensePlate { get; set; }

        [Column("model")]
        [Required(ErrorMessage = "The model is required")]
        public string? Model { get; set; }

        [Column("brand")]
        [Required(ErrorMessage = "The brand is required")]
        public string? Brand { get; set; }

        [Column("userId")]
        [Required]
        public int UserId { get; set; }
       
        [Column("color")]
        [Required(ErrorMessage = "The color is required")]
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
