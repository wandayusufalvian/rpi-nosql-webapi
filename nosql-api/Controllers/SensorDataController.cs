using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using nosql_api.Models;
using nosql_api.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

        [HttpGet("writejson")]
        public string GetWriteJson()
        {
            int dataQuantity = 86400;
            return JsonFileServices.WriteJsonFile(dataQuantity);
        }
        [HttpGet("readjsoneachline/{step}")]
        public string GetJsonEachLines(int step)
        {
            //return JsonFileServices.ReadJsonEachLines(step);
            return JsonFileServices.ReadJsonEachLines2(step);
        }

        [HttpGet("downloadjson")]
        public IActionResult DownloadJson()
        {
            var net = new System.Net.WebClient();
            var data = net.DownloadData(@"C:\Users\DELL\yusuf-frmltrx\rpi-nosql-webapi\nosql-api\Data\ini-2.json");
            var content = new System.IO.MemoryStream(data);
            var contentType = "application/json";
            var fileName = "ini-2.json";
            return File(content, contentType, fileName);
        }

        [HttpGet("jsonstring")]
        public string GetRawJson()
        {
            return JsonFileServices.GetJson2();
        }

        [HttpGet("jsonobject")]
        public IEnumerable<SensorData> Getjson()
        {
            return JsonFileServices.GetJson1();
        }

        [HttpGet("writedocsraven")]
        public string WriteDocs()
        {
            return RavenServices.WriteDocs();
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
