using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VintageCarGarageAPI.Models;
using VintageCarGarageAPI.Services;

namespace VintageCarGarageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ServiceService _serviceService;

        public ServicesController(ServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // GET /api/services
        [HttpGet]
        public ActionResult<IEnumerable<Service>> GetServices()
        {
            return Ok(_serviceService.GetAllServices());
        }
    }
}