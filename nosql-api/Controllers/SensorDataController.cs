using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nosql_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorDataController : ControllerBase
    {
        private readonly ILogger<SensorDataController> _logger;

        public SensorDataController(ILogger<SensorDataController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<SensorData> Get()
        {
            var rng = new Random();
            DateTime dt = new DateTime(2021,1,1,0,0,0);
            return Enumerable.Range(0, 5).Select(index => new SensorData
            {   
                datetime= dt.AddSeconds(index),
                sensorData =new List<double>
                {
                    rng.Next(0, 10),rng.Next(0, 10),rng.Next(0, 10),rng.Next(0, 10),rng.Next(0, 10)
                }
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        public IEnumerable<SensorData> GetA()
        {
            var rng = new Random();
            DateTime dt = new DateTime(2021, 1, 1, 0, 0, 0);
            return Enumerable.Range(0, 2).Select(index => new SensorData
            {
                datetime = dt.AddSeconds(index),
                sensorData = new List<double>
                {
                    rng.Next(0, 10),rng.Next(0, 10),rng.Next(0, 10),rng.Next(0, 10),rng.Next(0, 10)
                }
            })
            .ToArray();
        }
    }
}
