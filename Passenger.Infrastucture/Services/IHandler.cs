using System;
using System.Threading.Tasks;

namespace Passenger.Infrastucture.Services
{
    public interface IHandler : IService
    {
        IHandlerTask Run(Func<Task> runAsync);
        IHandlerTaskRunner Validate(Func<Task> validateAsync);
        Task ExecuteAllAsync();         
    }
}