namespace MiniBank.Api.DTOs.UsersDTOs
{
    public record UpdateUserInputModel(string FirstName, string LastName, string Document, string Email, string Password);
}
