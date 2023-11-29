using System.Diagnostics.CodeAnalysis;

namespace MiniBank.Api.Models
{
    public class User
    {
        public Guid Id { get; private init; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CpfOrCnpj { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int MyProperty { get; set; }
        public UserType UserType { get; set; }
    }
}
