using System;

namespace Passenger.Infrastucture.Commands
{
    public interface IAuthenticatedCommand: ICommand
    {
       Guid UserId { get; set; }
    }
}