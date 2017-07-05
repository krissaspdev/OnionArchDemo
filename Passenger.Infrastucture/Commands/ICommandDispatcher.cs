using System.Threading.Tasks;

namespace Passenger.Infrastucture.Commands
{
    public interface ICommandDispatcher
    {
         Task DispatchAsync<T> (T command) where T: ICommand;
    }
}