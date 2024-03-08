using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CoVoyageurCore.Models;

namespace CoVoyageurCore.Models
{
    [Table("profile")]
    public class Profile
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("rating")]
        [Required]
        public int? Rating { get; set; }

        [Column("review")]
        [Required]
        public string? Review { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<Car>? Cars { get; set; }

        public Preference Preferences { get; set; }

        public enum Preference
        {
            Musique,
            Tabac,
            Animaux
        }

      //  public ICollection<User> Users { get; set; }


    }
}
