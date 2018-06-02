using System.Collections.Generic;
using System.Threading.Tasks;
using ReserveApi.Models;

namespace ReserveApi.Repository
{
    public interface IAppointmentsRepository
    {
        Task<IEnumerable<Appointments>> GetAllAppointments();
        Task<Appointments> GetAppointments(string id);
        Task Create(Appointments appointments);
        Task<bool> Update(Appointments appointments);
        Task<bool> Delete(string id);
    }
}
