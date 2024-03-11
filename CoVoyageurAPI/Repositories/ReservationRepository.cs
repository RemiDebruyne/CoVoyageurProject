using CoVoyageurAPI.Datas;
using CoVoyageurCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoVoyageurAPI.Repositories
{
    public class ReservationRepository : IRepository<Reservation>
    {
        private ApplicationDbContext _dbContext { get; }
        public ReservationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CREATE
        public async Task<int> Add(Reservation reservation)
        {
            var addedObj = await _dbContext.Reservations.AddAsync(reservation);
            await _dbContext.SaveChangesAsync();
            return addedObj.Entity.Id;
        }

        // READ
        public async Task<Reservation?> GetById(int id)
        {
            return await _dbContext.Reservations.FindAsync(id);
        }
        public async Task<Reservation?> Get(Expression<Func<Reservation, bool>> predicate)
        {
            return await _dbContext.Reservations.FirstOrDefaultAsync(predicate);
        }
        public async Task<List<Reservation>> GetAll()
        {
            return await _dbContext.Reservations.ToListAsync();
        }
        public async Task<List<Reservation>> GetAll(Expression<Func<Reservation, bool>> predicate)
        {
            return await _dbContext.Reservations.Where(predicate).ToListAsync();
        }

        // UPDATE
        public async Task<bool> Update(Reservation reservation)
        {
            var reservationFromDb = await GetById(reservation.Id);

            if (reservationFromDb == null)
                return false;

            if (reservationFromDb.UserId != reservation.UserId)
                reservationFromDb.UserId = reservation.UserId;
            if (reservationFromDb.RideId != reservation.RideId)
                reservationFromDb.RideId = reservation.RideId;
            if (reservationFromDb.Ride != reservation.Ride)
                reservationFromDb.Ride = reservation.Ride;
            if (reservationFromDb.ReservationDate != reservation.ReservationDate)
                reservationFromDb.ReservationDate = reservation.ReservationDate;
            if (reservationFromDb.Status != reservation.Status)
                reservationFromDb.Status = reservation.Status;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        // DELETE
        public async Task<bool> Delete(int id)
        {
            var reservation = await GetById(id);
            if (reservation == null)
                return false;
            _dbContext.Reservations.Remove(reservation);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
