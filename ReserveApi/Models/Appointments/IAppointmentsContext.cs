using MongoDB.Driver;

namespace ReserveApi.Models
{
    public interface IAppointmentsContext
    {
        IMongoCollection<Appointments> Appointments { get; }
    }
}
