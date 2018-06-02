using System.Collections.Generic;
using System.Threading.Tasks;
using ReserveApi.Models;

namespace ReserveApi.Repository
{
    public interface IPatientsRepository
    {
        Task<IEnumerable<Patients>> GetAllPatients();
        Task<Patients> GetPatients(string id);
        Task Create(Patients patients);
        Task<bool> Update(Patients patients);
        Task<bool> Delete(string id);
    }
}
