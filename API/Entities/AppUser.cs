using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API.Entities;

[Index(nameof(UserName), IsUnique = true)]
public class AppUser
{
    public int Id { get; set; }
    public required string UserName { get; set;}
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
}