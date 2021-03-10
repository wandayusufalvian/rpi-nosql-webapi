using nosql_api.Models;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nosql_api.Services
{
    public class RavenServices
    {
        //write docs untuk tsdb2 karena yang sebelumnya broken jadi harus bikin lagi 
        public static string WriteDocs()
        {
            using (IDocumentSession session = DocumentStoreHolderRaven2.Store.OpenSession())
            {
                DateTime awal = new DateTime(2021, 1, 1, 0, 0, 0);

                for (int i = 0; i < 86400; i++)
                {
                    SensorData2 sd = new SensorData2();
                    DateTime dt = awal.AddSeconds(i);
                    sd.datetime = dt;
                    sd.ModFive = (new TimeSpan(dt.Ticks - awal.Ticks)).TotalSeconds % 5;
                    sd.ModTen = (new TimeSpan(dt.Ticks - awal.Ticks)).TotalSeconds % 10;
                    Random random = new Random();
                    sd.sensorData = new double[5];
                    for (int j = 0; j < 5; j++)
                    {
                        sd.sensorData[j] = random.NextDouble();
                    }
                    session.Store(sd);
                }

                session.SaveChanges();
                return "success write data";


            }
        }
        public static IEnumerable<SensorData> RetrieveAllDocs()
        {
            using (IDocumentSession session = DocumentStoreHolderRaven.Store.OpenSession())
            {
                /* To get data sensor: 
                 * returned list (l) => l.sensorData (list object) => use index to get the value(e.g. : l.sensorData[0])
                 */
                return session
                        .Query<SensorData>()
                        .Take(8640)
                        .Select(x => x)
                        .ToList();
            }
        }

        public static IEnumerable<SensorData2> RetrieveAllDocs2()
        {
            using (IDocumentSession session = DocumentStoreHolderRaven2.Store.OpenSession())
            {
                /* To get data sensor: 
                 * returned list (l) => l.sensorData (list object) => use index to get the value(e.g. : l.sensorData[0])
                 */
                return  session
                        .Query<SensorData2>()
                        .Take(8640)
                        .Select(x => x)
                        .ToList();

            }
        }

        public static IEnumerable<SensorData2> RetrieveAllDocsModFive()
        {
            using (IDocumentSession session = DocumentStoreHolderRaven2.Store.OpenSession())
            {

                return session
                        .Query<SensorData2>()
                        .Where(x => x.ModFive == 0)
                        .Select(x => x)
                        .ToList();
            }
        }

        public static IEnumerable<SensorData2> RetrieveAllDocsModTen()
        {
            using (IDocumentSession session = DocumentStoreHolderRaven2.Store.OpenSession())
            {

                return session
                        .Query<SensorData2>()
                        .Where(x => x.ModTen == 0)
                        .Select(x => x)
                        .ToList();
            }
        }
    }
}
