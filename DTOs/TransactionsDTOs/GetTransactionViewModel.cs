using MiniBank.Api.Models;

namespace MiniBank.Api.DTOs
{
     public record GetTransactionViewModel(Guid? IdTransaction, Guid IdSender, string? NameSender, Guid IdReceiver, string NameReceiver, decimal Value, string HourOfTransaction, string DateOfTransaction);
}
