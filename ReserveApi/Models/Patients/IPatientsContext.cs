using MongoDB.Driver;

namespace ReserveApi.Models
{
    public interface IPatientsContext
    {
        IMongoCollection<Patients> Patients { get; }
    }
}
