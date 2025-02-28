using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VintageCarGarageAPI.Models;
using VintageCarGarageAPI.Services;

namespace VintageCarGarageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarService _carService;

        public CarsController(CarService carService)
        {
            _carService = carService;
        }

        // GET /api/cars
        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetCars()
        {
            return Ok(_carService.GetAllCars());
        }

        // GET /api/cars/{id}
        [HttpGet("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            var car = _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }
    }
}