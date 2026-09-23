using Microsoft.AspNetCore.Identity.Data;
using TrackIt.Application.DTOs;
using TrackIt.Domain.Entities;

namespace TrackIt.Application.Services
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(UserRegistrationRequest userRegistrationRequest); 
        Task<string> LoginAsync(UserLoginRequest userLoginRequest);
    }
}
