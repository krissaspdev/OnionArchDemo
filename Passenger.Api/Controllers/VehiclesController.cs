using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastucture.Commands;
using Passenger.Infrastucture.Services;

namespace Passenger.Api.Controllers
{
    public class VehiclesController : ApiControllerBase
    {
        private readonly IVehicleProvider _vehicleProvider;
        public VehiclesController(ICommandDispatcher commandDispatcher, IVehicleProvider vehicleProvider) : base(commandDispatcher)
        {
            _vehicleProvider = vehicleProvider;
        }

        public async Task<IActionResult> Get()
        {
            //Logger.Info("AUTKO");
            var vehicles = await _vehicleProvider.BrowseAcync();

            return Json(vehicles);
        }        
    }
}