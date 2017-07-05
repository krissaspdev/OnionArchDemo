using System.Threading.Tasks;
using Passenger.Infrastucture.Commands;
using Passenger.Infrastucture.Commands.Drivers;
using Passenger.Infrastucture.Services;

namespace Passenger.Infrastucture.Handlers.Drivers
{
    public class CreateDriverHandler: ICommandHandler<CreateDriver>
    {

        private readonly IDriverService _driverService;
          public CreateDriverHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async Task HandleAsync(CreateDriver command)
        {
            await _driverService.CreateAsync(command.UserId);
            var vahicle = command.Vehicle;
            await _driverService.SetVehicleAsync(command.UserId, vahicle.Brand, vahicle.Name);
        }
    }
}