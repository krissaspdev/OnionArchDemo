using System;
using System.Threading.Tasks;
using Passenger.Infrastucture.Commands;
using Passenger.Infrastucture.Commands.Drivers;
using Passenger.Infrastucture.Services;

namespace Passenger.Infrastucture.Handlers.Drivers
{
    public class UpdateDriverHandler : ICommandHandler<UpdateDriver>
    {
        private readonly IDriverService _driverService;

        public UpdateDriverHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async Task HandleAsync(UpdateDriver command)
        {
            var vehicle = command.Vehicle;
            await _driverService.SetVehicle(command.UserId, vehicle.Brand, vehicle.Name);
        }
    }
}