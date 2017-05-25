using System;
using System.Threading.Tasks;
using Passenger.Core.Repositories;
using Passenger.Infrastucture.DTO;

namespace Passenger.Infrastucture.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        public DriverService (IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }
        public async Task<DriverDto> GetAsync(Guid userId)
        {
            var driver = await _driverRepository.GetAsync(userId);

            return new DriverDto
            {
                //id 
            };
        }
    }
}