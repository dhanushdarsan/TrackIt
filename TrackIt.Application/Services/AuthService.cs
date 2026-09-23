using Microsoft.AspNetCore.Identity.Data;
using TrackIt.Domain.Entities;
using TrackIt.Application.Interfaces;
using TrackIt.Application.DTOs;

namespace TrackIt.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtService _jwtService;

        public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public async Task<User> RegisterAsync(UserRegistrationRequest userRegistrationRequest)
        {
            var existingUser = await _userRepository.GetByEmailAsync(userRegistrationRequest.Email);

            if (existingUser != null)
            {
                throw new InvalidOperationException(
                    "User with this email already exists.");
            }

            var passwordHash = _passwordHasher.HashPassword(userRegistrationRequest.Password);

            var user = new User
            {
                Email = userRegistrationRequest.Email,
                PasswordHash = passwordHash,
                RoleId = 2
            };

            return await _userRepository.AddAsync(user);
        }

        public async Task<string> LoginAsync(UserLoginRequest userLoginRequest)
        {
            var user = await _userRepository.GetByEmailAsync(userLoginRequest.Email);

            if (user == null || !_passwordHasher.VerifyPassword(user.PasswordHash, userLoginRequest.Password))
            {
                throw new InvalidOperationException("Invalid email or password.");
            }

            return _jwtService.GenerateToken(user);
        }
    }
}

