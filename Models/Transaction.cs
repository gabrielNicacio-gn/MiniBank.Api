namespace MiniBank.Api.Models
{
    public class Transaction
    {
        public Guid Id { get; private init; }
        public User? Sender { get; set; }
        public User? Receiver { get; set; }
        public long Value { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
