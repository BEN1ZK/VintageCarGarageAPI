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

        // POST /api/cars
        [HttpPost]
        public ActionResult<Car> CreateCar([FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest("Car data is null.");
            }

            // Add the new car via the service which should save it to the database
            _carService.AddCar(car);

            // Return the created car with a 201 Created response, including a location header
            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
        }
    }
}
