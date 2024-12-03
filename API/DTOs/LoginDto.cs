using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public record class LoginDto(
    [Required]
    string UserName,
    [Required]
    string Password
);