using System.Collections.Generic;
using VintageCarGarageAPI.Models;
using VintageCarGarageAPI.Repositories;

namespace VintageCarGarageAPI.Services
{
    public class ServiceService
    {
        private readonly ServiceRepository _serviceRepository;

        public ServiceService(ServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public IEnumerable<Service> GetAllServices()
        {
            return _serviceRepository.GetAllServices();
        }

        public Service GetServiceById(int id)
        {
            return _serviceRepository.GetServiceById(id);
        }

        public void AddService(Service service)
        {
            _serviceRepository.AddService(service);
        }

        public void UpdateService(Service service)
        {
            _serviceRepository.UpdateService(service);
        }

        public void DeleteService(int id)
        {
            _serviceRepository.DeleteService(id);
        }
    }
}