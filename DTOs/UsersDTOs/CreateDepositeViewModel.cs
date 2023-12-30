namespace MiniBank.Api.DTOs.UsersDTOs
{
    public struct CreateDepositeViewModel
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public DateTime HourOfDeposite { get; set; }

        public CreateDepositeViewModel()
        {
            HourOfDeposite = DateTime.Now; 
        }
        public CreateDepositeViewModel(Guid id, decimal value)
        {
            Id = id;
            Value = value;
        }
    }
}
