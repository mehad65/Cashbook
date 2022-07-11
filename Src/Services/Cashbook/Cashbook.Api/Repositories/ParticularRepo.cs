using Cashbook.Api.Data;
using Cashbook.Api.Entities;
using MongoDB.Driver;

namespace Cashbook.Api.Repositories
{
    public class ParticularRepo : IParticularRepo
    {
        private readonly ICashbookContext _context;

        public ParticularRepo(ICashbookContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task CreateParticular(Particular particular)
        {
            await _context.Particulars.InsertOneAsync(particular);
        }

        public async Task<bool> DeleteParticular(string id)
        {
            FilterDefinition<Particular> filter = Builders<Particular>.Filter.Eq(p => p.Particular_Id, id);

            DeleteResult deleteResult = await _context
                                                .Particulars
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<Particular> GetParticular(string id)
        {
            return await _context
                           .Particulars
                           .Find(p => p.Particular_Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Particular>> GetParticulars()
        {
            return await _context
                            .Particulars
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<bool> UpdateParticular(Particular particular)
        {
            var updateResult = await _context
                                        .Particulars
                                        .ReplaceOneAsync(filter: g => g.Particular_Id == particular.Particular_Id, replacement: particular);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
