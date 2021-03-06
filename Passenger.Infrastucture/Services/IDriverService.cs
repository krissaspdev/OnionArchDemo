using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Passenger.Infrastucture.DTO;

namespace Passenger.Infrastucture.Services
{
    public interface IDriverService :IService
    {
        Task<DriverDetailsDto> GetAsync(Guid userId);
        Task<IEnumerable<DriverDto>> BrowseAsync();
        Task CreateAsync(Guid userId);
        Task SetVehicleAsync(Guid userId, string brand, string name);
        Task DeleteAsync(Guid userId);
        Task SetVehicle(Guid userId, string brand, string name);
    }
}