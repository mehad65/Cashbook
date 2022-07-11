using Cashbook.Api.Entities;

namespace Cashbook.Api.Repositories
{
    public interface ITransactionRepo
    {
        Task<IEnumerable<Transaction>> GetTransactions();
        Task<Transaction> GetTransaction(string id);
        Task CreateTransaction(Transaction transaction);
        Task<bool> UpdateTransaction(Transaction transaction);
        Task<bool> DeleteTransaction(string id);
    }
}
