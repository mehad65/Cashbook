using Cashbook.Api.Entities;
using MongoDB.Driver;

namespace Cashbook.Api.Data
{
    public class CashbookDataSeed
    {
        public static void TransactionSeedData(IMongoCollection<Transaction> transactionCollection)
        {
            bool existProduct = transactionCollection.Find(p => true).Any();
            if (!existProduct)
            {
                transactionCollection.InsertManyAsync(GetPreconfiguredTransactions());
            }
        }
        public static void ParticularSeedData(IMongoCollection<Particular> particularCollection)
        {
            bool existProduct = particularCollection.Find(p => true).Any();
            if (!existProduct)
            {
                particularCollection.InsertManyAsync(GetPreconfiguredParticulars());
            }
        }

        private static IEnumerable<Particular> GetPreconfiguredParticulars()
        {
            return new List<Particular>()
            {
                new Particular()
                {
                    Particular_Id = "602d2149e773f2a3990b47f5",
                    Particular_Name = "IPhone X",
                    Particular_Details = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                }
            };
        }
        private static IEnumerable<Transaction> GetPreconfiguredTransactions()
        {
            return new List<Transaction>()
            {
                new Transaction()
                {
                    Tran_Id = "602d2149e773f2a3990b47f5",
                    Tran_Amount=45,
                    Tran_Date = DateTime.Now,
                    Tran_EntryDate = DateTime.Now,
                    Tran_ParticularId="602d2149e773f2a3990b47f5",
                    Tran_Remarks="Good",
                    Tran_Type="GoodType",
                    Tran_UserId="5"
                }
            };
        }
    }
}
