using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using ReserveApi.Models;

namespace ReserveApi.Repository
{
    public class PracticeRepository : IPracticeRepository
    {
        private readonly IPracticeContext context;

        public PracticeRepository(IPracticeContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Practice>> GetAllPractice()
        {
            return await context
                    .Practice
                    .Find(_ => true)
                    .ToListAsync();
        }

        public Task<Practice> GetPractice(string id)
        {
            FilterDefinition<Practice> filter = Builders<Practice>.Filter.Eq(m => m.Practice_id, id);

            return context
                    .Practice
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }


        public async Task Create(Practice practice)
        {
            await context.Practice.InsertOneAsync(practice);
        }

        public async Task<bool> Update(Practice practice)
        {
            ReplaceOneResult updateResult =
                await context
                    .Practice
                    .ReplaceOneAsync(
                        filter: g => g.Id == practice.Id,
                        replacement: practice);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Practice> filter = Builders<Practice>.Filter.Eq(m => m.Practice_id, id);

            DeleteResult deleteResult = await context
                        .Practice
                        .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
