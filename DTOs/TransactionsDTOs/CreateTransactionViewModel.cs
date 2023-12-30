using MiniBank.Api.Models;

namespace MiniBank.Api.DTOs
{
     public record CreateTransactionViewModel(Guid? Id, Guid IdSender, string? NameSender, Guid IdReceiver, string NameReceiver, decimal Value, string HourOfTransaction,string DateOfTransaction);
}
