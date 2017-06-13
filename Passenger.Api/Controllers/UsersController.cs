using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastucture.Commands;
using Passenger.Infrastucture.Commands.Users;
using Passenger.Infrastucture.DTO;
using Passenger.Infrastucture.Services;

namespace Passenger.Api.Controllers
{
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {

        private readonly IUserService _userService;
        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher): base(commandDispatcher)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            return Json(user);

        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await CommandDispatcher.DispachAsync(command);
            return Created($"users/{command.Email}", new object());
        }
    }
}
