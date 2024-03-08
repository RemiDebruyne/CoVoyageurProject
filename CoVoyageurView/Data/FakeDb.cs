using CoVoyageurCore.Datas;
using CoVoyageurCore.Models;

namespace CoVoyageurView.Data
{
    public class FakeDb
    {
        public List<User> Users { get; set; } = InitialCoVoyageur.users;
        public List<Ride> Rides { get; set; } = InitialCoVoyageur.rides;
        public List<Rating> Rating { get; set; } = InitialCoVoyageur.ratings;
        public List<Profile> Profiles { get; set; } = InitialCoVoyageur.profiles;
        public List<Car> Cars { get; set; } = InitialCoVoyageur.cars;

    }
}
