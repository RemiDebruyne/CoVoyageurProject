using CoVoyageurAPI.Datas;
using CoVoyageurCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoVoyageurAPI.Repositories
{
    public class ProfileRepository : IRepository<Profile>
    {
        private ApplicationDbContext _dbContext { get; }
        public ProfileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CREATE
        public async Task<int> Add(Profile profile)
        {
            var addedObj = await _dbContext.Profiles.AddAsync(profile);
            await _dbContext.SaveChangesAsync();
            return addedObj.Entity.Id;
        }

        // READ
        public async Task<Profile?> GetById(int id)
        {
            return await _dbContext.Profiles.FindAsync(id);
        }
        public async Task<Profile?> Get(Expression<Func<Profile, bool>> predicate)
        {
            return await _dbContext.Profiles.FirstOrDefaultAsync(predicate);
        }
        public async Task<List<Profile>> GetAll()
        {
            return await _dbContext.Profiles.ToListAsync();
        }
        public async Task<List<Profile>> GetAll(Expression<Func<Profile, bool>> predicate)
        {
            return await _dbContext.Profiles.Where(predicate).ToListAsync();
        }

        // UPDATE
        public async Task<bool> Update(Profile profile)
        {
            var profileFromDb = await GetById(profile.Id);

            if (profileFromDb == null)
                return false;

            if (profileFromDb.Rating != profile.Rating)
                profileFromDb.Rating = profile.Rating;
            if (profileFromDb.Review != profile.Review)
                profileFromDb.Review = profile.Review;
            if (profileFromDb.UserId != profile.UserId)
                profileFromDb.UserId = profile.UserId;
            if (profileFromDb.Cars != profile.Cars)
                profileFromDb.Cars = profile.Cars;
            if (profileFromDb.Preferences != profile.Preferences)
                profileFromDb.Preferences = profile.Preferences;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        // DELETE
        public async Task<bool> Delete(int id)
        {
            var profile = await GetById(id);
            if (profile == null)
                return false;
            _dbContext.Profiles.Remove(profile);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
