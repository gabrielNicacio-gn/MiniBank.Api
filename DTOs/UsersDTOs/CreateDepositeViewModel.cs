namespace MiniBank.Api.DTOs.UsersDTOs
{
    public struct CreateDepositeViewModel
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public DateTime HourDeposite { get; set; }

        public CreateDepositeViewModel(Guid id,decimal value)
        {
            Id = id;
            Value = value;
            HourDeposite = DateTime.Now;
        }
    }
}
