using System;
using System.Threading.Tasks;
using Passenger.Infrastucture.Commands;
using Passenger.Infrastucture.Commands.Drivers;
using Passenger.Infrastucture.Services;

namespace Passenger.Infrastucture.Handlers.Drivers
{
    public class DeleteDriverRouteHandler : ICommandHandler<CreateDriverRoute>
    {
                private readonly IDriverRouteService _driverRouteService;

        public DeleteDriverRouteHandler(IDriverRouteService driverRouteService)
        {
            _driverRouteService = driverRouteService;
        }

        public async Task HandleAsync(CreateDriverRoute command)
        {
            await _driverRouteService.DeleteAsync(command.UserId, command.Name);
        }  
    }
}