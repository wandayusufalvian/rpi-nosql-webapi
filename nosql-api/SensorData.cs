using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nosql_api
{
    public class SensorData
    {
        public DateTime datetime { get; set; }
        public List<double> sensorData { get; set; }


    }
}
