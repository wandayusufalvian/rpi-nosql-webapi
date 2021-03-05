using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace nosql_api.Services
{
    public class DocumentStoreHolderRaven
    {
        //session untuk database timeseries 
        private static readonly Lazy<IDocumentStore> LazyStore =
        new Lazy<IDocumentStore>(() =>
        {
            var store = new DocumentStore
            {
                Urls = new[] { "https://a.frmltrx.development.run/" },
                Database = "timeseries",
                Certificate = new X509Certificate2("C:\\Users\\DELL\\Downloads\\admin.client.certificate.frmltrx.pfx")
            };

            return store.Initialize();
        });

        public static IDocumentStore Store => LazyStore.Value;
    }
}
