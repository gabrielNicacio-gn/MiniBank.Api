using Microsoft.VisualBasic;
using MiniBank.Api.Data;
using MiniBank.Api.Models;


namespace MiniBank.Api.Repository
{
    public class TransactionRepository
    {
        private readonly BankDb _bankDb;
        public TransactionRepository(BankDb bankDb)
        {
            _bankDb = bankDb;
        }
        public async Task CreateTransaction(Transaction transaction)
        {
          await _bankDb.Transactions.AddAsync(transaction);
          await _bankDb.SaveChangesAsync();
        }
        /*
        public Task<Transaction> SearchForUserTransactions(Guid id)
        {
           
        }
        */
    }
}
