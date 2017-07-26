using System;
using System.Threading.Tasks;

namespace Passenger.Infrastucture.Services
{
    public interface IHandlerTaskRunner
    {
         IHandlerTask Run(Func<Task> runAsync);  
    }
}