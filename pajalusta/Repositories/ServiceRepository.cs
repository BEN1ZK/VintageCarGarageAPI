using System.Collections.Generic;
using System.Linq;
using VintageCarGarageAPI.Data;
using VintageCarGarageAPI.Models;

namespace VintageCarGarageAPI.Repositories
{
    public class ServiceRepository
    {
        private readonly InsideBoxContext _context;

        public ServiceRepository(InsideBoxContext context)
        {
            _context = context;
        }

        public IEnumerable<Service> GetAllServices()
        {
            return _context.Services.ToList();
        }

        public Service GetServiceById(int id)
        {
            return _context.Services.FirstOrDefault(s => s.Id == id);
        }

        public void AddService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
        }

        public void DeleteService(int id)
        {
            var service = _context.Services.FirstOrDefault(s => s.Id == id);
            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
        }
    }
}