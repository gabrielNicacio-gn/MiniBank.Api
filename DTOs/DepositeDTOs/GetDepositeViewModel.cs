namespace MiniBank.Api.DTOs.DepositeDTOs
{
    public record GetDepositeViewModel(Guid IdDeposite, Guid IdUser, string UserName, decimal Value, string HourDeposite, string DateDeposite);
}
