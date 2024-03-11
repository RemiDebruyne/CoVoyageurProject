using CoVoyageurAPI.Datas;
using CoVoyageurCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoVoyageurAPI.Repositories
{
    public class RideRepository : IRepository<Ride>
    {
        private ApplicationDbContext _dbContext { get; }
        public RideRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CREATE
        public async Task<int> Add(Ride ride)
        {
            var addedObj = await _dbContext.Rides.AddAsync(ride);
            await _dbContext.SaveChangesAsync();
            return addedObj.Entity.Id;
        }

        // READ
        public async Task<Ride?> GetById(int id)
        {
            return await _dbContext.Rides.FindAsync(id);
        }
        public async Task<Ride?> Get(Expression<Func<Ride, bool>> predicate)
        {
            return await _dbContext.Rides.FirstOrDefaultAsync(predicate);
        }
        public async Task<List<Ride>> GetAll()
        {
            return await _dbContext.Rides.ToListAsync();
        }
        public async Task<List<Ride>> GetAll(Expression<Func<Ride, bool>> predicate)
        {
            return await _dbContext.Rides.Where(predicate).ToListAsync();
        }

        // UPDATE
        public async Task<bool> Update(Ride ride)
        {
            var rideFromDb = await GetById(ride.Id);

            if (rideFromDb == null)
                return false;

            if (rideFromDb.UserId != ride.UserId)
                rideFromDb.UserId = ride.UserId;
            if (rideFromDb.CreationDate != ride.CreationDate)
                rideFromDb.CreationDate = ride.CreationDate;
            if (rideFromDb.RideDate != ride.RideDate)
                rideFromDb.RideDate = ride.RideDate;
            if (rideFromDb.Price != ride.Price)
                rideFromDb.Price = ride.Price;
            if (rideFromDb.AvailableSeats != ride.AvailableSeats)
                rideFromDb.AvailableSeats = ride.AvailableSeats;
            if (rideFromDb.Departure != ride.Departure)
                rideFromDb.Departure = ride.Departure;
            if (rideFromDb.Arrival != ride.Arrival)
                rideFromDb.Arrival = ride.Arrival;
            if (rideFromDb.Ratings != ride.Ratings)
                rideFromDb.Ratings = ride.Ratings;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        // DELETE
        public async Task<bool> Delete(int id)
        {
            var ride = await GetById(id);
            if (ride == null)
                return false;
            _dbContext.Rides.Remove(ride);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
