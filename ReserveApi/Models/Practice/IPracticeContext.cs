using MongoDB.Driver;

namespace ReserveApi.Models
{
    public interface IPracticeContext
    {
        IMongoCollection<Practice> Practice { get; }
    }
}
