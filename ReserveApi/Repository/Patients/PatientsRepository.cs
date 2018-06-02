using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using ReserveApi.Models;

namespace ReserveApi.Repository
{
    public class PatientsRepository : IPatientsRepository
    {
        private readonly IPatientsContext context;

        public PatientsRepository(IPatientsContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Patients>> GetAllPatients() 
        {
                return await context
                        .Patients
                        .Find(_ => true)
                        .ToListAsync();
        }

        public Task<Patients> GetPatients(string id)
        {
            FilterDefinition<Patients> filter = Builders<Patients>.Filter.Eq(m => m.Patient_id, id);

            return context
                    .Patients
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Create(Patients patients)
        {
            await context.Patients.InsertOneAsync(patients);
        }

        public async Task<bool> Update(Patients patients)
        {
            ReplaceOneResult updateResult =
                await context
                    .Patients
                    .ReplaceOneAsync(
                     g => g.Id == patients.Id,
                     patients);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Patients> filter = Builders<Patients>.Filter.Eq(m => m.Patient_id, id);

            DeleteResult deleteResult = await context
                        .Patients
                        .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
