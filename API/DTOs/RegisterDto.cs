using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Entities;

namespace API.DTOs;

public record RegisterDto(
    [Required]
    string UserName,
    [Required]
    string Password
);