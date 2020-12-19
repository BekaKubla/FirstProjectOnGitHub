using SellAutoProject.Data;
using SellAutoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellAutoProject.Repositories
{
    public class CarRepo : ICarRepos
    {
        private readonly AppDbContext _context;

        public CarRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateCar(Car car)
        {
            if (car == null)
            {
                throw new Exception("ragac");
            }
            _context.Cars.Add(car);
        }

        public void DeleteCar(Car car)
        {
            if (car == null)
            {
                throw new Exception("ragac");
            }
            _context.Cars.Remove(car);
        }


        public Car GetCarByID(int id)
        {
            return _context.Cars.FirstOrDefault(o => o.ID == id);
        }

        public IEnumerable<Car> GetCars(string value)
        {
            IEnumerable<Car> myCars;
            switch (value)
            {
                case "desc":
                    myCars = _context.Cars.OrderByDescending(q => q.DateTime);
                    break;
                case "asc":
                    myCars = _context.Cars.OrderBy(q => q.DateTime);
                    break;
                default:
                    myCars = _context.Cars;
                    break;

            }
            return myCars;
        }

        public IEnumerable<Car> PagingCar(int pageNumber, int pageSize)
        {
            var carPaging = _context.Cars;
            return carPaging.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Car> SearchCar(string type)
        {
            return _context.Cars.Where(q => q.Name.StartsWith(type));
        }

        public void UpdateCar(Car car)
        {
            //nothing
        }
    }
}
