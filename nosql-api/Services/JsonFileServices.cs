using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using nosql_api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
                JsonSerializer serializer = new JsonSerializer();
                return (SensorData[])serializer.Deserialize(jsonFileReader, typeof(SensorData[]));
            } 
        }

        public static string GetJsonString()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\DELL\yusuf-frmltrx\rpi-nosql-webapi\nosql-api\Data\ini-86400.json"))
            {
                char[] c = new char[12644865];
                r.Read(c, 0, 12644865); 
                return new string(c);
            }
        }

        public static string WriteJsonFile(int dataQuantity)
        {   //json text in each line (1 file)
            DateTime awal = new DateTime(2021, 1, 1, 0, 0, 0);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dataQuantity; i++)
            {
                SensorData sd = new SensorData();
                DateTime dt = awal.AddSeconds(i);
                sd.datetime = dt;
                Random random = new Random();
                sd.sensorData = new double[5];
                for (int j = 0; j < 5; j++)
                {
                    sd.sensorData[j] = random.NextDouble();
                }
                string jsonFile = JsonConvert.SerializeObject(sd);
                sb.Append(jsonFile + Environment.NewLine);
            }
            System.IO.File.WriteAllText(@"C:\Users\DELL\yusuf-frmltrx\rpi-nosql-webapi\nosql-api\Data\json-86400.json", sb.ToString());
            return "success write data";
        }

        public static string ReadJsonEachLine()
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader r = new StreamReader(@"C:\Users\DELL\yusuf-frmltrx\rpi-nosql-webapi\nosql-api\Data\json-5.json"))
            {
                int i= 0;
                while (i<5)
                {
                    if (i % 5 == 0)
                    {
                        sb.Append(r.ReadLine()+Environment.NewLine);
                    }
                    else { r.ReadLine(); }
                    i++;
                }
            }return sb.ToString(); 
        }
    }
}
