using Passenger.Infrastucture.Commands;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastucture.Commands.Accounts;
using System;
using Passenger.Infrastucture.Extensions;

namespace Passenger.Api.Controllers
{
    public class LoginController : ApiControllerBase
    {
        private readonly IMemoryCache _cache;
        public LoginController(ICommandDispatcher commandDispatcher, IMemoryCache cache) : base(commandDispatcher)
        {
            _cache = cache;
        }

        public async Task<IActionResult> Post([FromBody] Login command)
        {
            command.TokenId = Guid.NewGuid();
            await CommandDispatcher.DispachAsync(command);
            var jwt = _cache.GetJwt(command.TokenId);

            return Json(jwt);
        }
    }
}