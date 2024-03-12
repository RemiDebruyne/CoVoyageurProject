using Blazored.LocalStorage;
using CoVoyageurCore.Models;
using System.Net.Http.Json;

namespace CoVoyageurView.Services
{
    public class UserState
    {
        public User User { get; set; }
        public Profile Profile { get; set; }
    }
}
