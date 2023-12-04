using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite.Migrations.Internal;
using Microsoft.VisualBasic;
using MiniBank.Api.Data;
using MiniBank.Api.Models;
using MiniBank.Api.ViewModel;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace MiniBank.Api.Repository
{
    public class UserRepository
    {
        private readonly BankDb _bankDb;
        public UserRepository(BankDb bankDb)
        {
            _bankDb = bankDb;
        }

        public async Task<IQueryable<User>> GetAllUserAsync()
        {
            var list = await _bankDb.Users
                .Where(prop => prop.IsActivate)
                .ToListAsync();
            return list.AsQueryable();
        }
        public async Task<User?> GetUsersByIdAsync(Guid id)
        {
            var user = await _bankDb.Users
                .Where(prop => prop.Id == id && prop.IsActivate)
                .SingleOrDefaultAsync();
                return user;
        }
        public async Task<User?> GetUserByDocument(string document) 
        {
            var user = await _bankDb.Users
                .Where(prop => prop.Document == document && prop.IsActivate)
                .SingleOrDefaultAsync();
                return user;
        }
        public async Task<bool> CreateUser(User newUser)
        {
            var exist = await _bankDb.Users.AnyAsync(userExist=>userExist.Email == newUser.Email && userExist.Document == newUser.Document);
            if (!exist)
            {
                await _bankDb.Users.AddAsync(newUser);
                await _bankDb.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateUser(Guid id, DataEntryToUpdateUser dataEntry)
        {
            using (var transaction = _bankDb.Database.BeginTransaction())
            {
                var affeted = await _bankDb.Users
                .Where(user => user.Id == id && user.IsActivate)
                .ExecuteUpdateAsync(user => user
                .SetProperty(prop => prop.FirstName, dataEntry.FirstName)
                .SetProperty(prop => prop.LastName, dataEntry.LastName)
                .SetProperty(prop => prop.Document, dataEntry.Document)
                .SetProperty(prop => prop.Email, dataEntry.Email)
                );
                if(affeted == 0)
                {
                    transaction.Rollback();
                    return false;
                }
                transaction.Commit();
                return true;
            }
        }
        public async Task<bool> DeleteUser(Guid id) 
        {
            var affeted = await _bankDb.Users
                .Where(prop => prop.Id == id && prop.IsActivate)
                .ExecuteUpdateAsync(user => user
                .SetProperty(prop=>prop.IsActivate,false));
            if (affeted == 0)
            {
                return false;  
            }
            return true;
        }
    }
}
