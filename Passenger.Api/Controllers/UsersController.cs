using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastucture.Commands.Users;
using Passenger.Infrastucture.DTO;
using Passenger.Infrastucture.Services;

namespace Passenger.Api.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {

        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public UserDto Get(string email)
        => _userService.Get(email);

        [HttpPost("")]
        public void Post([FromBody]CreateUser request)
        {
            _userService.Register(request.Email, request.Username, request.Password);
        }
    }
}
