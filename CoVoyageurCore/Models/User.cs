using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoVoyageurCore.Models
{
    [Table("user")]
    public class User
    {
        //[Column("id")]
        public int Id { get; set; }
        //[Column("firstname")]
        //[Required]
        //[RegularExpression(@"^[A-Z][A-Za-z\- ]*", ErrorMessage = "FirstName must start with an uppercase letter !")]
        public string? FirstName { get; set; }
        //[Column("lastname")]
        //[Required]
        //[RegularExpression(@"^[A-Z\- ]*", ErrorMessage = "LastName must be in uppercase !")]
        public string? LastName { get; set; }
        public string? FullName => FirstName + " " + LastName; // get => pas d'attribut/variable FullName

        //[Column("email")]
        //[Required]
        public string? Email { get; set; }

        //[Column("phone")]
        //[Required]
        public string? Phone { get; set; }

        //[Column("password")]
        //[Required]
        public string? Password { get; set; }

        //[Column("birth_date")]
        //[Required]
        //[JsonIgnore] // la prop sera ignorée pour la serialisation de l'objet
        public DateTime BirthDate { get; set; }

        //[Column("gender")]
        //[Required]
        //[RegularExpression(@"[FMN]", ErrorMessage = "Gender must be either F, M, or N.")]
        //[StringLength(1)]
        public string? Gender { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
