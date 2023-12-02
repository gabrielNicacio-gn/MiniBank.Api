using MiniBank.Api.Enums;

namespace MiniBank.Api.ViewModel
{
    public record DataEntryToCreateUser(string FirstName, string LastName, string Document, string Email, string Password, decimal Balance, UserType TheUserType);
}
