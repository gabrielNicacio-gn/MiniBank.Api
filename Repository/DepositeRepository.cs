using Microsoft.EntityFrameworkCore;
using MiniBank.Api.Data;
using MiniBank.Api.Models;
using System.Collections;

namespace MiniBank.Api.Repository
{
    public class DepositeRepository
    {
        private readonly BankDb _bankDb;
        public DepositeRepository(BankDb bankDb) 
        {
            _bankDb = bankDb;
        }
        public async Task CreateDeposite(Deposite deposite)
        {
            await _bankDb.Deposites.AddAsync(deposite);
            await _bankDb.SaveChangesAsync();
        }
        public async Task<IQueryable<Deposite>> GetDepositesAsync(Guid id)
        {
            var listDeposites = await _bankDb.Deposites
                .Where(prop => prop.UserId == id)
                .OrderByDescending(prop => prop.DepositeDateAndTime)
                .ToListAsync();
            return listDeposites.AsQueryable();
        }
        
    }
}
