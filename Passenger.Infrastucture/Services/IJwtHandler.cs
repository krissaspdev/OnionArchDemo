using Passenger.Infrastucture.DTO;

namespace Passenger.Infrastucture.Services
{
    public interface IJwtHandler
    {
         JwtDto CreateToken(string email, string role);
    }
}