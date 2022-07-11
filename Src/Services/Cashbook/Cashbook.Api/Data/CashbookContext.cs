using Cashbook.Api.Entities;
using MongoDB.Driver;

namespace Cashbook.Api.Data
{
    public class CashbookContext : ICashbookContext
    {
        public IMongoCollection<Particular> Particulars { get; }

        public IMongoCollection<Transaction> Transactions { get; }
        public CashbookContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var Db = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Particulars = Db.GetCollection<Particular>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            Transactions = Db.GetCollection<Transaction>(configuration.GetValue<string>("DatabaseSettings:CollectionName1"));
            CashbookDataSeed.ParticularSeedData(Particulars);
            CashbookDataSeed.TransactionSeedData(Transactions);
        }
    }
}
