using System;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace ReserveApi.Models
{
    public class appointmentsContext : IPatientsContext
    {
        private readonly IMongoDatabase db;

        public appointmentsContext(IOptions<DBSettings> options)
        {
            
            var client = new MongoClient(options.Value.ConnectionString);
            if (client != null)
                db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Patients> Patients => db.GetCollection<Patients>("Patients"); 
    }
}
