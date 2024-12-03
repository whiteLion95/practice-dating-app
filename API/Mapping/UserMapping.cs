using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;

namespace API.Mapping
{
    public static class UserMapping
    {
        public static AppUser ToUser(this RegisterDto regDto)
        {
            using var hmac = new HMACSHA512();

            return new AppUser
            {
                UserName = regDto.UserName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(regDto.Password)),
                PasswordSalt = hmac.Key
            };
        }

        public static UserDto ToDto(this AppUser user, ITokenService tokenService)
        {
            return new UserDto
            (
                UserName: user.UserName,
                Token: tokenService.CreateToken(user)
            );
        }
    }
}