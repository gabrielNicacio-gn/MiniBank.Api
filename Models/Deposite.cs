using System.ComponentModel.DataAnnotations;

namespace MiniBank.Api.Models
{
    public class Deposite
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public User? Depositor { get; set; }
        public Guid UserId { get; set; }
        [Required]
        public decimal Value { get; set; }
        [Required]
        public DateTime DepositeDateAndTime { get; set; }
        public Deposite()
        {
            
        }

        public Deposite(User depositor, decimal value)
        {
            Id = Guid.NewGuid();
            Depositor = depositor;
            Value = value;
            DepositeDateAndTime = DateTime.Now;
        }

    }
    
}
