using System.ComponentModel.DataAnnotations;
namespace Shared.DataTransferObjects.AuthenticationDtos;

public record UserForRegistrationDto
{
    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    [Required(ErrorMessage = "Username is a required field.")]
    public string? UserName { get; init; }

    [Required(ErrorMessage = "Password is a required field.")]
    public string? Password { get; init; }
    
    public string? Email { get; init; }
    
    public string? PhoneNumber { get; init; }
    
    public ICollection<string>? Roles { get; init; }
}