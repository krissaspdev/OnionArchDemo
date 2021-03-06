using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Passenger.Infrastucture.Commands;
using Passenger.Infrastucture.Commands.Accounts;
using Passenger.Infrastucture.Services;
using Passenger.Infrastucture.Extensions;

namespace Passenger.Infrastucture.Handlers.Accounts
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IHandler _handler;
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;
        public LoginHandler(IHandler handler, IUserService userService, IJwtHandler jwtHandler,
        IMemoryCache cache)
        {
            _handler = handler;
            _userService = userService;
            _jwtHandler = jwtHandler;
            _cache = cache;
        }

        public async Task HandleAsync(Login command)
        => await _handler
            .Run(async () => await _userService.LoginAsync(command.Email, command.Password))
            .Next()
            .Run(async () =>
	        {
	            var user = await _userService.GetAsync(command.Email);
	            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
	            _cache.SetJwt(command.TokenId, jwt);
	        })
            .ExecuteAsync();

        // public async Task HandleAsync(Login command)
        // {
        //     await _userService.LoginAsync(command.Email, command.Password);
        //     var user = await _userService.GetAsync(command.Email);
        //     var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
        //     _cache.SetJwt(command.TokenId, jwt);
        // }
    }
}