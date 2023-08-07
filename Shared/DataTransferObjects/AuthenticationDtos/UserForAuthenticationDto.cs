using System.ComponentModel.DataAnnotations;
namespace Shared.DataTransferObjects.AuthenticationDtos;

public record  UserForAuthenticationDto
{
    [Required(ErrorMessage = "Username is a required field.")]
    public string? UserName { get; init; }

    [Required(ErrorMessage = "Password is a required field.")]
    public string? Password { get; init; }
}
