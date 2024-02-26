﻿using CoVoyageurCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoVoyageurCore.Models
{
    public class Ride
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RideDate { get; set; }
        public decimal Price { get; set; }
        public int AvailableSeats { get; set; }
        public int UserId { get; set; } 
        public User User { get; set; }
        public string Departure { get; set; }
        public string  Arrival { get; set; }
    }
}
