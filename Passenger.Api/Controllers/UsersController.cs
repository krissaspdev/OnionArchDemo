using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastucture.Commands;
using Passenger.Infrastucture.Commands.Users;
using Passenger.Infrastucture.DTO;
using Passenger.Infrastucture.Services;
using Passenger.Infrastucture.Settings;

namespace Passenger.Api.Controllers
{
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {

        private readonly IUserService _userService;
        private readonly GeneralSettings _settings;
        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher, GeneralSettings settings): base(commandDispatcher)
        {
            _userService = userService;
            _settings = settings;
        }
        
       //[Authorize(Policy="admin")]
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.BrowseAsync();
            return Json(users);
        }        

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await DispatchAsync(command);
            return Created($"users/{command.Email}", null);
        }
    }
}
