using Passenger.Infrastucture.Commands.Drivers.Models;

namespace Passenger.Infrastucture.Commands.Drivers
{
    public class UpdateDriver : AuthenticatedCommandBase
    {
        public DriverVehicle Vehicle {get; set;}
    }
}