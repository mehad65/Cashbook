using Cashbook.Api.Data;
using Cashbook.Api.Entities;
using MongoDB.Driver;

namespace Cashbook.Api.Repositories
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly ICashbookContext _context;

        public TransactionRepo(ICashbookContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task CreateTransaction(Transaction Transaction)
        {
            await _context.Transactions.InsertOneAsync(Transaction);
        }

        public async Task<bool> DeleteTransaction(string id)
        {
            FilterDefinition<Transaction> filter = Builders<Transaction>.Filter.Eq(p => p.Tran_Id, id);

            DeleteResult deleteResult = await _context
                                                .Transactions
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<Transaction> GetTransaction(string id)
        {
            return await _context
                           .Transactions
                           .Find(p => p.Tran_Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            return await _context
                            .Transactions
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<bool> UpdateTransaction(Transaction Transaction)
        {
            var updateResult = await _context
                                        .Transactions
                                        .ReplaceOneAsync(filter: g => g.Tran_Id == Transaction.Tran_Id, replacement: Transaction);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
