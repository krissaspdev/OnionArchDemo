using System.Collections.Generic;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Infrastucture.DTO;

namespace Passenger.Infrastucture.Services
{
    public interface IVehicleProvider: IService
    {
        Task<IEnumerable<VehicleDto>> BrowseAcync();
        Task<VehicleDto> GetAsync(string brand, string name);
    }
}