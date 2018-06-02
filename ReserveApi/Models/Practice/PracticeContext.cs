using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace ReserveApi.Models
{
    public class PracticeContext : IPracticeContext
    {
        private readonly IMongoDatabase db;

        public PracticeContext(IOptions<DBSettings> options)
        {

            var client = new MongoClient(options.Value.ConnectionString);
            if (client != null)
                db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Practice> Practice => db.GetCollection<Practice>("Practice");
    }
}
