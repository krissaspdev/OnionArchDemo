using System;
using System.Threading.Tasks;
using Passenger.Infrastucture.DTO;

namespace Passenger.Infrastucture.Services
{
    public interface IDriverService: IService
    {
        Task<DriverDto> GetAsync(Guid userId);
    }
}