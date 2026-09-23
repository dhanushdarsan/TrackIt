using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TrackIt.Application.Interfaces;

namespace TrackIt.Infrastructure.Security
{
    public class PasswordHasherService : IPasswordHasher
    {
        private readonly PasswordHasher<object> _hasher = new();
        public string HashPassword(string password)
        {
            return _hasher.HashPassword(null, password);    
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var result = _hasher.VerifyHashedPassword(null!, hashedPassword, providedPassword);

            return result == PasswordVerificationResult.Success;
        }
    }
}
