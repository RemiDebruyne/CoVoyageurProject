using CoVoyageurCore.Models;
using System.Numerics;
using System.Reflection;

namespace CoVoyageurCore.Datas
{
    public static class InitialCoVoyageur
    {
        public static readonly List<User> users = new List<User>()
        {
            new User{ Id = 1, FirstName ="Kevin", LastName = "Callet", Email = "kevin@mail.com", Phone="0102030405", Password = "pswd", BirthDate = new DateTime(2000, 1, 1), Gender = "M", IsAdmin = false },
            new User{ Id = 2, FirstName ="Massima", LastName = "Mao", Email = "massimo@mail.com", Phone="0102030405", Password = "pswd", BirthDate = new DateTime(2000, 1, 1), Gender = "M", IsAdmin = false },
            new User{ Id = 3, FirstName ="Rémi", LastName = "Debruyne", Email = "remi@mail.com", Phone="0102030405", Password = "pswd", BirthDate = new DateTime(2000, 1, 1), Gender = "M", IsAdmin = false },
            new User{ Id = 4, FirstName ="Aguit", LastName = "Inan", Email = "aguit@mail.com", Phone="0102030405", Password = "pswd", BirthDate = new DateTime(2000, 1, 1), Gender = "M", IsAdmin = false },
        };

        public static readonly List<Profile> profiles = new List<Profile>()
        {
            new Profile{ Id = 1, Rating = 5, Review = "¨Parfait", Preferences = Profile.Preference.Animaux, UserId = 1},
            new Profile{ Id = 2, Rating = 4, Review = "Bien", Preferences = Profile.Preference.Tabac, UserId = 2},
            new Profile{ Id = 3, Rating = 3, Review = "Moyen", Preferences = Profile.Preference.Musique, UserId = 3},
            new Profile{ Id = 4, Rating = 2, Review = "Mauvais", Preferences = Profile.Preference.Animaux, UserId = 4},
        };

        public static readonly List<Car> cars = new List<Car>()
        {
            new Car{ Id = 1, LicensePlate = "OG-666-OG", Model = "Fiesta", Brand = "Ford", UserId = 1, Color = Car.CarColor.Red},
            new Car{ Id = 2, LicensePlate = "AB-123-RT", Model = "Fiesta", Brand = "Ford", UserId = 2, Color = Car.CarColor.Red},
            new Car{ Id = 3, LicensePlate = "AB-123-RT", Model = "Fiesta", Brand = "Ford", UserId = 3, Color = Car.CarColor.Red},
            new Car{ Id = 4, LicensePlate = "AB-123-RT", Model = "Fiesta", Brand = "Ford", UserId = 4, Color = Car.CarColor.Red},
        };

        public static readonly List<Ride> rides = new List<Ride>()
        {
            new Ride{ Id = 1, CreationDate = new DateTime(2000, 1, 1), RideDate = new DateTime(2000, 1, 1), Price = 20.00M, AvailableSeats = 4, UserId = 1, Arrival = "10h00",Departure = "9h00"},
            new Ride{ Id = 2, CreationDate = new DateTime(2000, 1, 1), RideDate = new DateTime(2000, 1, 1), Price = 20.00M, AvailableSeats = 4, UserId = 2, Arrival = "10h00",Departure = "9h00"},
            new Ride{ Id = 3, CreationDate = new DateTime(2000, 1, 1), RideDate = new DateTime(2000, 1, 1), Price = 20.00M, AvailableSeats = 4, UserId = 3, Arrival = "10h00",Departure = "9h00"},
            new Ride{ Id = 4, CreationDate = new DateTime(2000, 1, 1), RideDate = new DateTime(2000, 1, 1), Price = 20.00M, AvailableSeats = 4, UserId = 4, Arrival = "10h00",Departure = "9h00"},
        };

        public static readonly List<Reservation> reservations = new List<Reservation>()
        {
            new Reservation{ Id = 1, UserId = 1, RideId = 2, ReservationDate = new DateTime(2000, 1, 1), Status = Reservation.ReservationStatus.Confirmed},
            new Reservation{ Id = 2, UserId = 3, RideId = 4, ReservationDate = new DateTime(2000, 1, 1), Status = Reservation.ReservationStatus.Confirmed},
        };

        public static readonly List<Rating> ratings = new List<Rating>()
{
    new Rating
    {
        Id = 1,
        UserId = 1,
        RideId = 1,
        RatingUserId = 1,
        RatedUserId = 1,
        Score = 5,
        Comment = "Good",
        RatingDate = new DateTime(2000, 1, 1)
    },
    new Rating
    {
        Id = 2,
        RideId = 2,
        RatingUserId = 2,
        RatedUserId = 2,
        Score = 2,
        Comment = "Bad",
        RatingDate = new DateTime(2000, 1, 1)
    }
};
    }
}
