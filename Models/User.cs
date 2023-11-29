using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MiniBank.Api.Enums;

namespace MiniBank.Api.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; private init; }

        [Required]
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(120)]
        public string? LastName { get; set; }
        [Required]
        [MaxLength(20)]
        public string? Document { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Email { get; set; }
        [Required]
        [MinLength(8)]
        public string? Password { get; set; }
        public decimal Balance { get; set; }
        [Required]
        public UserType UserType { get; set; }
    }
}
