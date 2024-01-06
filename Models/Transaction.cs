using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniBank.Api.Models
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; private init; }
        [Required]
        public User? Sender { get; private set; }
        public Guid SenderId { get; private set; }
        [Required]
        public User? Receiver { get; private set; }
        public Guid ReceiverId { get; private set; }    
        [Required]
        public decimal Value { get; private set; }
        [Required]
        public DateTime TransactionDateAndTime { get; private set; }

        public Transaction()
        {
            
        }

        public Transaction(User sender, User receiver, decimal value)
        {
            Id = Guid.NewGuid();
            Sender = sender;
            Receiver = receiver;
            Value = value;
            TransactionDateAndTime = DateTime.Now;
        }
        
    }
}
