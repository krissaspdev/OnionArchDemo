using System;

namespace Passenger.Infrastucture.Commands.Drivers
{
    public class DeleteDriverRoute: AuthenticatedCommandBase
    {
        public string Name { get; set; }
    }
}