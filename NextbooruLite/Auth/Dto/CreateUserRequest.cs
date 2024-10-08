using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace NextbooruLite.Auth.Dto;

public class CreateUserRequest
{
    [Required]
    public required string Username { get; set; }
    public string? Email { get; set; }
    
    [Required]
    public required string Password { get; set; }
    
    public Role Role { get; set; } = Role.User;

    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .Length(3, 16)
                .Matches("^[a-zA-Z0-9]+[a-zA-Z0-9_]*[a-zA-Z0-9]$")
                .WithMessage(
                    "Username can consist only of letters, numbers and underscores. Username cannot start or end with underscore.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(8, 72);
        }
    }
}