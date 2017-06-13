using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastucture.Commands;

namespace Passenger.Api.Controllers
{
    [Route("[controller]")]
    public abstract class ApiControllerBase: Controller
    {
        protected readonly ICommandDispatcher CommandDispatcher;
        protected ApiControllerBase (ICommandDispatcher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        }
    }
}