using VintageCarGarageAPI.Data;
using VintageCarGarageAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace VintageCarGarageAPI.Repositories
{
    public class CarRepository
    {
        private readonly InsideBoxContext _context;

        public CarRepository(InsideBoxContext context)
        {
            _context = context;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public Car GetCarById(int id)
        {
            return _context.Cars.FirstOrDefault(c => c.Id == id);
        }

        public void AddCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges(); // Ensures the change is committed to the database
        }

        // Optionally add update and delete methods as needed...
    }
}
