using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastucture.Commands;
using Passenger.Infrastucture.Commands.Drivers;
using Passenger.Infrastucture.Services;

namespace Passenger.Api.Controllers
{
    public class DriversController : ApiControllerBase
    {
        private readonly IDriverService _driverService;
        public DriversController(ICommandDispatcher commandDispatcher, IDriverService driverService) : base(commandDispatcher)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var drivers = await _driverService.BrowseAsync();
            return Json(drivers);
        } 
        
        [HttpPost("")]
        public async Task<IActionResult> Put([FromBody]CreateDriver command)
        {
            await CommandDispatcher.DispachAsync(command);
            return NoContent();
        }
    }
}