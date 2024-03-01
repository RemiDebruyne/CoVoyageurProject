using CoVoyageurAPI.Datas;
using CoVoyageurCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoVoyageurAPI.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private ApplicationDbContext _dbContext {  get; }

        public UserRepository(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        // CREATE
        public async Task<int> Add(User user)
        {
            var addedObj = await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return addedObj.Entity.Id;
        }

        // READ
        public async Task<User?> GetById(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<User?> Get(Expression<Func<User, bool>> predicate)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(predicate);
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAll(Expression<Func<User, bool>> predicate)
        {
            return await _dbContext.Users.Where(predicate).ToListAsync();
        }

        // UPDATE
        public async Task<bool> Update(User user)
        {
            var userFromDb = await GetById(user.Id);

            if (userFromDb == null)
                return false;

            if (userFromDb.FirstName != user.FirstName)
                userFromDb.FirstName = user.FirstName;
            if (userFromDb.LastName != user.LastName)
                userFromDb.LastName = user.LastName;
            if (userFromDb.Email != user.Email)
                userFromDb.Email = user.Email;
            if (userFromDb.Phone != user.Phone)
                userFromDb.Phone = user.Phone;
            if (userFromDb.BirthDate != user.BirthDate)
                userFromDb.BirthDate = user.BirthDate;
            if (userFromDb.Password != user.Password)
                userFromDb.Password = user.Password;
            if (userFromDb.Gender != user.Gender)
                userFromDb.Gender = user.Gender;
            if (userFromDb.IsAdmin != user.IsAdmin)
                userFromDb.IsAdmin = user.IsAdmin;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        // DELETE
        public async Task<bool> Delete(int id)
        {
            var user = await GetById(id);
            if (user == null)
                return false;
            _dbContext.Users.Remove(user);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
