using CoVoyageurCore.Models;
using CoVoyageurCore.Datas;
using Microsoft.EntityFrameworkCore;

namespace CoVoyageurAPI.Datas
{
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext() : base()
        //{
        //}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\CoVoyageur; Database=CoVoyageur; Integrated Security=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {        
            modelBuilder.Entity<Rating>()
                .HasOne(r => r.RatedUser)
                .WithMany(u=>u.RatedRatings)
                .HasForeignKey(r => r.RatedUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.RatingUser)
                .WithMany(u => u.RatingRatings)
                .HasForeignKey(r => r.RatingUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Ride)
                .WithMany()
                .HasForeignKey(r => r.RideId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Profile>()
                .Ignore(e => e.Preferences);

            modelBuilder.Entity<User>().HasData(InitialCoVoyageur.users);
            modelBuilder.Entity<Profile>().HasData(InitialCoVoyageur.profiles);
            modelBuilder.Entity<Car>().HasData(InitialCoVoyageur.cars);
            modelBuilder.Entity<Ride>().HasData(InitialCoVoyageur.rides);
            modelBuilder.Entity<Reservation>().HasData(InitialCoVoyageur.reservations);
            modelBuilder.Entity<Rating>().HasData(InitialCoVoyageur.ratings);
        }
    }
}
