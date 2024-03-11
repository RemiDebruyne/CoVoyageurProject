using CoVoyageurCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoVoyageurCore.DTOs
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public string Message { get; set; }
        public User User { get; set; }
    }
}
