using nosql_api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace nosql_api.Services
{
    public class JsonFileServices
    {
        public static IEnumerable<SensorData> GetDatasJson()
        {
            string dataLokal = @"C:\Users\DELL\yusuf-frmltrx\rpi-nosql-webapi\nosql-api\Data\ini-86400.json";
            string dataRpi = @"Z:\ts-api\Data\ini-86400.json";
            using (var jsonFileReader = File.OpenText(dataLokal))
            {
                return JsonSerializer.Deserialize<SensorData[]>(jsonFileReader.ReadToEnd());
            }
        }

      
    }
}
