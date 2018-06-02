using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace ReserveApi.Models
{
    public class AppointmentsContext : IAppointmentsContext
    {
        private readonly IMongoDatabase db;

        public AppointmentsContext(IOptions<DBSettings> options)
        {

            var client = new MongoClient(options.Value.ConnectionString);
            if (client != null)
                db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Appointments> Appointments => db.GetCollection<Appointments>("Appointments");
    }
}
