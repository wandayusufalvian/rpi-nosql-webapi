using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nosql_api.Models
{
    public class SensorData2
    {
        public double ModFive { get; set; }
        public double ModTen { get; set; }
        public DateTime datetime { get; set; }
        public double[] sensorData { get; set; }
    }
}
