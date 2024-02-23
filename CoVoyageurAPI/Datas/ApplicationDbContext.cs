using CoVoyageurCore.Models;
using CoVoyageurCore.Datas;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CoVoyageurAPI.Datas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(InitialCoVoyageur.users);
            modelBuilder.Entity<Profile>().HasData(InitialCoVoyageur.profiles);
            modelBuilder.Entity<Car>().HasData(InitialCoVoyageur.cars);
            modelBuilder.Entity<Ride>().HasData(InitialCoVoyageur.rides);
            modelBuilder.Entity<Reservation>().HasData(InitialCoVoyageur.reservations);
            modelBuilder.Entity<Rating>().HasData(InitialCoVoyageur.ratings);
        }
    }
}
