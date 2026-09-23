using TrackIt.Domain.Entities;

namespace TrackIt.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
