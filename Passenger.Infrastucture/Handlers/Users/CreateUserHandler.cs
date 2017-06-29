using System;
using System.Threading.Tasks;
using Passenger.Infrastucture.Commands;
using Passenger.Infrastucture.Commands.Users;
using Passenger.Infrastucture.Services;

namespace Passenger.Infrastucture.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {

        private readonly IUserService _userService;
          public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(Guid.NewGuid(), command.Email, command.Username, command.Password, command.Role);
        }
    }
}