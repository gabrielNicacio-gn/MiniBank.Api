using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MiniBank.Api.Models
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; private init; }
        [Required]
        public User? Sender { get; set; }
        [Required]
        public User? Receiver { get; set; }
        [Required]
        public decimal Value { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
    }
}
