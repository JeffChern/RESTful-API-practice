using System.Collections.Generic;
using System.Threading.Tasks;
using ReserveApi.Models;

namespace ReserveApi.Repository
{
    public interface IPracticeRepository
    {
        Task<IEnumerable<Practice>> GetAllPractice();
        Task<Practice> GetPractice(string id);
        Task Create(Practice practice);
        Task<bool> Update(Practice practice);
        Task<bool> Delete(string id);
    }
}
