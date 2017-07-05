using System;
using Passenger.Infrastucture.DTO;

namespace Passenger.Infrastucture.Services
{
    public interface IJwtHandler
    {
         JwtDto CreateToken(Guid userId, string role);
    }
}