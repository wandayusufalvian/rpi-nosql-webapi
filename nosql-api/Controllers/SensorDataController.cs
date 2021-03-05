using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using nosql_api.Models;
using nosql_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        public string Get()
        {
            return "Connected";
        }

        [HttpGet("writedocs")]
        public string WriteDocs()
        {
            return RavenServices.WriteDocs();
        }

        [HttpGet("json")]
        public IEnumerable<SensorData> Getjson()
        {
            return JsonFileServices.GetDatasJson();
        }

        [HttpGet("ravendb1")] // untuk ravendb timeseries
        public IEnumerable<SensorData> GetRaven()
        {
            return RavenServices.RetrieveAllDocs();
        }

        [HttpGet("ravendb2")] // untuk ravendb tsdb2
        public IEnumerable<SensorData2> GetRaven2()
        {

            return RavenServices.RetrieveAllDocs2();
        }

        [HttpGet("ravendb2mod5")]
        public IEnumerable<SensorData2> GetRavenModFive()
        {
            return RavenServices.RetrieveAllDocsModFive();
        }

        [HttpGet("{ravendb2mod10}")]
        public IEnumerable<SensorData2> GetRavenModTen()
        {
            return RavenServices.RetrieveAllDocsModTen();
        }



    }
}
