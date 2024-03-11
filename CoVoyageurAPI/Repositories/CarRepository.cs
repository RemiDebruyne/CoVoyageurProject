using Microsoft.EntityFrameworkCore;
using CoVoyageurAPI.Datas;
using CoVoyageurCore.Models;
using System.Linq.Expressions;
using System;

namespace CoVoyageurAPI.Repositories
{
    public class CarRepository : IRepository<Car>
    {
        private ApplicationDbContext _dbContext { get; set; }
        public CarRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(Car car)
        {
            var addedObj = await _dbContext.Cars.AddAsync(car);
            await _dbContext.SaveChangesAsync();
            return addedObj.Entity.Id;
        }

        public async Task<Car?> GetById(int id)
        {
            return await _dbContext.Cars.FindAsync(id);
        }

        public async Task<Car?> Get(Expression<Func<Car, bool>> predicate)
        {
            return await _dbContext.Cars.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<Car>> GetAll()
        {
            return await _dbContext.Cars.ToListAsync();
        }


        public async Task<List<Car>> GetAll(Expression<Func<Car, bool>> predicate)
        {
            return await _dbContext.Cars.Where(predicate).ToListAsync();
        }

        public async Task<bool> Update(Car car)
        {
            var carFromDb = await GetById(car.Id);

            if (carFromDb == null)
                return false;

            if (carFromDb.LicensePlate != car.LicensePlate)
                carFromDb.LicensePlate = car.LicensePlate;
            if (carFromDb.Model != car.Model)
                carFromDb.Model = car.Model;
            if (carFromDb.Brand != car.Brand)
                carFromDb.Brand = car.Brand;
            if (carFromDb.Color != car.Color)
                carFromDb.Color = car.Color;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var car = await GetById(id);
            if (car == null)
                return false;
            _dbContext.Cars.Remove(car);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
