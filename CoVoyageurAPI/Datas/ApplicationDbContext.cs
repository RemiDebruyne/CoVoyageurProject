using CoVoyageurCore.Models;
using CoVoyageurCore.Datas;
using Microsoft.EntityFrameworkCore;

namespace CoVoyageurAPI.Datas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=(localdb)\\MSSQLLocalDB; Database=CoVoyageurProject;");
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>()
            .HasMany(t => t.RatedUserId);
       

            modelBuilder.Entity<User>().HasData(InitialCoVoyageur.users);   
            modelBuilder.Entity<Profile>().HasData(InitialCoVoyageur.profiles);
            modelBuilder.Entity<Car>().HasData(InitialCoVoyageur.cars);
            modelBuilder.Entity<Ride>().HasData(InitialCoVoyageur.rides);
            modelBuilder.Entity<Reservation>().HasData(InitialCoVoyageur.reservations);
            modelBuilder.Entity<Rating>().HasData(InitialCoVoyageur.ratings);
        }
    }
}
