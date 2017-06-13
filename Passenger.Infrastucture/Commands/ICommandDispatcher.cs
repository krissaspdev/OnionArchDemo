using System.Threading.Tasks;

namespace Passenger.Infrastucture.Commands
{
    public interface ICommandDispatcher
    {
         Task DispachAsync<T> (T command) where T: ICommand;
    }
}