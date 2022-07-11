using Cashbook.Api.Entities;
using MongoDB.Driver;

namespace Cashbook.Api.Data
{
    public interface ICashbookContext
    {
        public IMongoCollection<Particular> Particulars { get; }
        public IMongoCollection<Transaction> Transactions { get; }
    }
}
