using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using ReserveApi.Models;

namespace ReserveApi.Repository
{
    public class AppointmentsRespository : IAppointmentsRepository
    {
        private readonly IAppointmentsContext context;

        public AppointmentsRespository(IAppointmentsContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Appointments>> GetAllAppointments()
        {
            return await context
                    .Appointments
                    .Find(_ => true)
                    .ToListAsync();
        }

        public Task<Appointments> GetAppointments(string id)
        {
            FilterDefinition<Appointments> filter = Builders<Appointments>.Filter.Eq(m => m.Patient_id, id);

            return context
                    .Appointments
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }


        public async Task Create(Appointments appointments)
        {
            await context.Appointments.InsertOneAsync(appointments);
        }

        public async Task<bool> Update(Appointments appointments)
        {
            ReplaceOneResult updateResult =
                await context
                    .Appointments
                    .ReplaceOneAsync(
                         g => g.Id == appointments.Id,
                         appointments);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Appointments> filter = Builders<Appointments>.Filter.Eq(m => m.Patient_id, id);

            DeleteResult deleteResult = await context
                        .Appointments
                        .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
