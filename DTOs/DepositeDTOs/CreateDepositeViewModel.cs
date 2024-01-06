namespace MiniBank.Api.DTOs.DepositeDTOs
{
    public record CreateDepositeViewModel(Guid idDeposite,Guid IdUser, string UserName ,decimal Value,string HourDeposite, string DateDeposite );
}
