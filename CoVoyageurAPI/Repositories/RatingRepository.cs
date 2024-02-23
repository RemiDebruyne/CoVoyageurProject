using CoVoyageurAPI.Datas;
using CoVoyageurCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoVoyageurAPI.Repositories
{
    public class RatingRepository : IRepository<Rating>
    {
        private ApplicationDbContext _dbContext { get; }

        public RatingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CREATE
        public async Task<int> Add(Rating rating)
        {
            var addedObj = await _dbContext.Ratings.AddAsync(rating);
            await _dbContext.SaveChangesAsync();
            return addedObj.Entity.Id;
        }

        // READ
        public async Task<Rating?> GetById(int id)
        {
            return await _dbContext.Ratings.FindAsync(id);
        }

        public async Task<Rating?> Get(Expression<Func<Rating, bool>> predicate)
        {
            return await _dbContext.Ratings.FirstOrDefaultAsync(predicate);
        }

        public Task<List<Rating>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Rating>> GetAll(Expression<Func<Rating, bool>> predicate)
        {
            return await _dbContext.Ratings.Where(predicate).ToListAsync();
        }

        // UPDATE
        public async Task<bool> Update(Rating rating)
        {
            var ratingFromDb = await GetById(rating.Id);

            if (ratingFromDb == null)
                return false;

            if (ratingFromDb.RideId != rating.RideId)
                ratingFromDb.RideId = rating.RideId;
            if (ratingFromDb.Ride != rating.Ride)
                ratingFromDb.Ride = rating.Ride;
            if (ratingFromDb.RatedUserId != rating.RatedUserId)
                ratingFromDb.RatedUserId = rating.RatedUserId;
            if (ratingFromDb.RatedUser != rating.RatedUser)
                ratingFromDb.RatedUser = rating.RatedUser;
            if (ratingFromDb.RatingUserId != rating.RatingUserId)
                ratingFromDb.RatingUserId = rating.RatingUserId;
            if (ratingFromDb.RatingUser != rating.RatingUser)
                ratingFromDb.RatingUser = rating.RatingUser;
            if (ratingFromDb.Score != rating.Score)
                ratingFromDb.Score = rating.Score;
            if (ratingFromDb.Comment != rating.Comment)
                ratingFromDb.Comment = rating.Comment;
            if (ratingFromDb.RatingDate != rating.RatingDate)
                ratingFromDb.RatingDate = rating.RatingDate;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        // DELETE
        public async Task<bool> Delete(int id)
        {
            var rating = await GetById(id);
            if (rating == null)
                return false;
            _dbContext.Ratings.Remove(rating);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}