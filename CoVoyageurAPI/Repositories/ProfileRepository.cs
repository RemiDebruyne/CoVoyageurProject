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

        public Task<List<Profile>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Profile>> GetAll(Expression<Func<Profile, bool>> predicate)
        {
            return await _dbContext.Profiles.Where(predicate).ToListAsync();
        }

        // UPDATE
        public async Task<bool> Update(Profile Profile)
        {
            var ProfileFromDb = await GetById(Profile.Id);

            if (ProfileFromDb == null)
                return false;

            if (ProfileFromDb.Rating != Profile.Rating)
                ProfileFromDb.Rating = Profile.Rating;
            if (ProfileFromDb.Review != Profile.Review)
                ProfileFromDb.Review = Profile.Review;
            if (ProfileFromDb.UserId != Profile.UserId)
                ProfileFromDb.UserId = Profile.UserId;
            if (ProfileFromDb.User != Profile.User)
                ProfileFromDb.User = Profile.User;
            if (ProfileFromDb.Cars != Profile.Cars)
                ProfileFromDb.Cars = Profile.Cars;
            if (ProfileFromDb.Preferences != Profile.Preferences)
                ProfileFromDb.Preferences = Profile.Preferences;
        

            return await _dbContext.SaveChangesAsync() > 0;
        }

        // DELETE
        public async Task<bool> Delete(int id)
        {
            var Profile = await GetById(id);
            if (Profile == null)
                return false;
            _dbContext.Profiles.Remove(Profile);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
