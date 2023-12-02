using MiniBank.Api.Enums;

namespace MiniBank.Api.ResultsCustomizer.DTOs
{
    public record OutputDataGetUsers(Guid Id, string? FirstName, string? LastName, string? Document, string? Email, decimal Balance, UserType TheUserType);

}
