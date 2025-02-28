﻿using System.Collections.Generic;
using System.Linq;
using VintageCarGarageAPI.Data;
using VintageCarGarageAPI.Models;

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
            _context.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            _context.Cars.Update(car);
            _context.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }
    }
}