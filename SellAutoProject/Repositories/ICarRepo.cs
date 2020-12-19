using SellAutoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellAutoProject.Repositories
{
    public interface ICarRepos
    {
        IEnumerable<Car> GetCars(string value);
        IEnumerable<Car> PagingCar(int PageSize, int PageNumber);
        IEnumerable<Car> SearchCar(string type);
        Car GetCarByID(int id);
        void CreateCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(Car car);
        bool SaveChange();
    }
}
