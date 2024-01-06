using MiniBank.Api.Enums;

namespace MiniBank.Api.DTOs.UsersDTOs
{
    public record GetUsersViewModel(Guid IdUser, string? FirstName, string? LastName, string? Document, string? Email, decimal Balance, UserType TheUserType);

}
