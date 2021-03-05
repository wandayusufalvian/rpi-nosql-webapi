using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nosql_api.Models
{
    public class SensorData
    {
        public DateTime datetime { get; set; }
        public double[] sensorData { get; set; }


    }
}
