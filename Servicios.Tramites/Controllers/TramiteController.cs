using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Servicios.Tramites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Tramites.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TramiteController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public TramiteController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Tramite> GetTramites()
        {
            var result = new List<Tramite>();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.Tramite.ToList();
            }

            return result;
        }
    }
}
