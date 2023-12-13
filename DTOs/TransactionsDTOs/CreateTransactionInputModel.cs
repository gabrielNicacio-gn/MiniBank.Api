namespace MiniBank.Api.DTOs.TransactionsDTOs
{
    public record CreateTransactionInputModel(Guid IdSender, Guid IdReceiver, decimal Value);

}
