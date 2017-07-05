using System.Collections.Generic;

namespace Passenger.Infrastucture.DTO
{
    public class DriverDetailsDto: DriverDto
    {
        public IEnumerable<RouteDto> Routes { get; set; }
    }
}