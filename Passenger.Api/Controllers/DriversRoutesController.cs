using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastucture.Commands;
using Passenger.Infrastucture.Commands.Drivers;
using Passenger.Infrastucture.Services;

namespace Passenger.Api.Controllers
{
    [Route("drivers/routes")]
    public class DriversRoutesController : ApiControllerBase
    {
        private readonly IDriverService _driverService;

        public DriversRoutesController(ICommandDispatcher commandDispatcher,
            IDriverService driverService) 
            : base(commandDispatcher)
        {
            _driverService = driverService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateDriverRoute command)
        {
            await DispatchAsync(command);

            return NoContent();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(string name)
        {
            var command = new DeleteDriverRoute
            {
                Name = name
            };

            await DispatchAsync(command);

            return NoContent();
        }  
    }
}