using SellAutoProject.Models;
using SellAutoProject.Repositories;
using SellAutoProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellAutoProject.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly ICarRepos _carRepo;

        public CarController(ICarRepos carRepo)
        {
            _carRepo = carRepo;
        }
        [HttpGet]
        [ResponseCache(Duration = 60)]
        public ActionResult GetAllCar(string value)
        {
            return Ok(_carRepo.GetCars(value));
        }
        [HttpGet("{id}")]
        public ActionResult GetCarByID(int id, DetailsViewModel detailsViewModel)
        {
            var findCar = _carRepo.GetCarByID(id);
            if (findCar == null)
            {
                return NotFound();
            }
            else
            {
                detailsViewModel.Name = findCar.Name;
                detailsViewModel.Model = findCar.Model;
                detailsViewModel.Price = findCar.Price;
            }
            return Ok(detailsViewModel);
        }
        [HttpGet("[action]")]
        public ActionResult PagingCar()
        {
            var pgNumber = 1;
            var pgSize = 5;
            var pagingCar = _carRepo.PagingCar(pgNumber, pgSize);
            return Ok(pagingCar);
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult SearchingCar(string type)
        {
            var searchCar = _carRepo.SearchCar(type);
            return Ok(searchCar);
        }
        [HttpPost]
        public ActionResult CreateCar(Car car)
        {
            _carRepo.CreateCar(car);
            _carRepo.SaveChange();
            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateCar([FromBody] UpdateViewModel updateViewModel, int id)
        {
            var findCar = _carRepo.GetCarByID(id);
            if (findCar == null)
            {
                return NotFound();
            }
            else
            {
                findCar.Name = updateViewModel.Name;
                findCar.Model = updateViewModel.Model;
                findCar.FuelType = updateViewModel.FuelType;
                findCar.Price = updateViewModel.Price;
                findCar.DateTime = updateViewModel.DateTime;
                _carRepo.SaveChange();
                return NoContent();
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteCar(int id)
        {
            var findCar = _carRepo.GetCarByID(id);
            if (findCar == null)
            {
                return NotFound();
            }
            _carRepo.DeleteCar(findCar);
            _carRepo.SaveChange();
            return NoContent();
        }
    }
}
