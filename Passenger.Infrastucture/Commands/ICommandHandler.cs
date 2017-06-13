using System.Threading.Tasks;

namespace Passenger.Infrastucture.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);         
    }
}