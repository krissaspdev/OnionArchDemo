using System;
using Passenger.Infrastucture.Commands.Drivers.Models;

namespace Passenger.Infrastucture.Commands.Drivers
{
    public class CreateDriver : AuthenticatedCommandBase
    {
        public DriverVehicle Vehicle { get; set; }
    }


}