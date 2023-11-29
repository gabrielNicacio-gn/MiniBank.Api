using MiniBank.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MiniBank.Api.Data
{
    public class BankDb:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = db_Bank");
            optionsBuilder.LogTo(Console.WriteLine);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(prop => prop.Email)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(prop => prop.Document)
                .IsUnique();
            modelBuilder.Entity<Transaction>()
                .HasOne(prop => prop.Sender)
                .WithMany(pro=>pro.TransactionsSender)
                .HasForeignKey(prop => prop.SenderId);
            modelBuilder.Entity<Transaction>()
                .HasOne(prop => prop.Receiver)
                .WithMany(pro => pro.TransactionsReceiver)
                .HasForeignKey(prop=>prop.ReceiverId);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
