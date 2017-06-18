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
            await Task.CompletedTask;
            //await _userService.RegisterAsync(command.Email, command.Username, command.Password);
        }
    }
}