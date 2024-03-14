using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoVoyageurCore.Models
{
    [Table("profile")]
    public class Profile
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("rating")]
        public int? Rating { get; set; }

        [Column("review")]
        public string? Review { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public List<Car>? Cars { get; set; }

        public List<Preference>? Preferences { get; set; }

        public enum Preference
        {
            Musique,
            Tabac,
            Animaux
        }

        public User User { get; set; }
        public int UserId { get; set; }
        public List<Car>? Cars { get; set; }
        public List<Preference>? Preferences { get; set; }
    }
}
