using CoVoyageurCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoVoyageurCore.Models
{
    [Table("car")]
    public class Car
    {
        //[Column("id")]
        public int Id { get; set; }

        //[Column("license_plate")]
        //[Required]
        public string? LicensePlate { get; set; }

        //[Column("model")]
        //[Required]
        public string? Model { get; set; }

        //[Column("brand")]
        //[Required]
        public string? Brand { get; set; }

        //[Column("color")]
        //[Required]
        public int UserId { get; set; }
        public User User { get; set; }
        public CarColor Color { get; set; }

        public enum CarColor
        {
            White,
            Black,
            Red,
            Green,
            Blue,
            Yellow,
            Pink
        }

    }
}
