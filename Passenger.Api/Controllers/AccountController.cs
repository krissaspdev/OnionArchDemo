using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Passenger.Infrastucture.Commands;
using Passenger.Infrastucture.Commands.Accounts;
using Passenger.Infrastucture.Commands.Users;
using Passenger.Infrastucture.Services;
using Passenger.Infrastucture.Extensions;
using Microsoft.AspNetCore.Authorization;
using System;

namespace Passenger.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IMemoryCache _cache;
        public AccountController(ICommandDispatcher commandDispatcher, IMemoryCache cache) : base(commandDispatcher)
        {
            _cache = cache;
        }


        [HttpPut("")]
        [Route("password")]
        public async Task<IActionResult> Put([FromBody]ChangeUserPassword command)
        {
            await CommandDispatcher.DispachAsync(command);
            return NoContent();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Post([FromBody]Login command)
        {
            await CommandDispatcher.DispachAsync(command);
            var jwt = _cache.GetJwt(Guid.NewGuid());

            return Json(jwt);
        }   

    }
}