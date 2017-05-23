using System;
using Passenger.Infrastucture.DTO;

namespace Passenger.Infrastucture.Services
{
    public interface IDriverService
    {
        DriverDto Get(Guid userId);
    }
}