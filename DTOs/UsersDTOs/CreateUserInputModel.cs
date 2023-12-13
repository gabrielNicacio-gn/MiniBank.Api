using MiniBank.Api.Enums;

namespace MiniBank.Api.DTOs.UsersDTOs
{
    public record CreateUserInputModel(string FirstName, string LastName, string Document, string Email, string Password, UserType TheUserType);
}
