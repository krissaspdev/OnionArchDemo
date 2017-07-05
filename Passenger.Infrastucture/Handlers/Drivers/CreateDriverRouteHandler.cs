using System;
using System.Threading.Tasks;
using Passenger.Infrastucture.Commands;
using Passenger.Infrastucture.Commands.Drivers;
using Passenger.Infrastucture.Services;

namespace Passenger.Infrastucture.Handlers.Drivers
{
    public class CreateDriverRouteHandler : ICommandHandler<CreateDriverRoute>
    {
        private readonly IDriverRouteService _driverRouteService;

        public CreateDriverRouteHandler(IDriverRouteService driverRouteService)
        {
            _driverRouteService = driverRouteService;
        }

        public async Task HandleAsync(CreateDriverRoute command)
        {
            await _driverRouteService.AddAsync(command.UserId, command.Name,
                command.StartLatitude, command.StartLongitude, 
                command.EndLatitude, command.EndLongitude);
        }  
    }
}