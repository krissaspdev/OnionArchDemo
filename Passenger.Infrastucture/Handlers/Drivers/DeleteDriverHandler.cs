using System.Threading.Tasks;
using Passenger.Infrastucture.Commands;
using Passenger.Infrastucture.Commands.Drivers;
using Passenger.Infrastucture.Services;

namespace Passenger.Infrastucture.Handlers.Drivers
{
    public class DeleteDriverHandler : ICommandHandler<DeleteDriver>
    {
        private readonly IDriverService _driverService;

        public DeleteDriverHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async Task HandleAsync(DeleteDriver command)
        {
            await _driverService.DeleteAsync(command.UserId);
        }
    }
}