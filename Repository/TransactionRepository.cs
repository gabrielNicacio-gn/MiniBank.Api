using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MiniBank.Api.Data;
using MiniBank.Api.DTOs;
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
       
        public async Task<IQueryable<Transaction>> SearchTransactionsReceivedByAUser(Guid id)
        {
           var transactions = await _bankDb.Transactions
                             .Where(x => x.ReceiverId == id || x.SenderId == id)
                             .OrderByDescending(x => x.TransactionDate)
                             .ToListAsync();
           return transactions.AsQueryable();
        }   
    }
}
