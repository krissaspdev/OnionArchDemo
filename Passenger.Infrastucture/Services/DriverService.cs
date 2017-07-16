using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastucture.DTO;
using Passenger.Infrastucture.Exceptions;
using Passenger.Infrastucture.Extensions;

namespace Passenger.Infrastucture.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IUserRepository _userRepository;
        private  readonly IVehicleProvider _vehicleProvider;
        private readonly IMapper _mapper;

        public DriverService(IDriverRepository driverRepository,
            IUserRepository userRepository, IVehicleProvider vehicleProvider, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _userRepository = userRepository;
            _vehicleProvider = vehicleProvider;
            _mapper = mapper;
        }

        public async Task<DriverDetailsDto> GetAsync(Guid userId)
        {
            var driver = await _driverRepository.GetAsync(userId);
            
            return _mapper.Map<DriverDetailsDto>(driver);
        }

        public async Task<IEnumerable<DriverDto>> BrowseAsync()
        {
            var drivers = await _driverRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<DriverDto>>(drivers);
        }

        public async Task CreateAsync(Guid userId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);

            var driver = await _driverRepository.GetAsync(userId);
            if(driver != null)
            {
                throw new ServiceException(Exceptions.ErrorCodes.DriverAlreadyExists, $"Driver with user id: '{userId}' already exists.");
            }
            driver = new Driver(user);
            await _driverRepository.AddAsync(driver);
        }

        public async Task SetVehicleAsync(Guid userId, string brand, string name)
        {
            var driver = await _driverRepository.GetOrFailAsync(userId);

            var vehicleDetails = await _vehicleProvider.GetAsync(brand, name);
            var vehicle = Vehicle.Create(brand, name, vehicleDetails.Seats);                
            driver.SetVehicle(vehicle);            
        }

        public async Task DeleteAsync(Guid userId)
        {
            var driver = await _driverRepository.GetOrFailAsync(userId);
            await _driverRepository.DeleteAsync(driver);            
        }

        public async Task SetVehicle(Guid userId, string brand, string name)
        {
            var driver = await _driverRepository.GetOrFailAsync(userId);
            var vehicleDetails = await _vehicleProvider.GetAsync(brand, name);
            var vehicle = Vehicle.Create(vehicleDetails.Brand, vehicleDetails.Name, vehicleDetails.Seats);
            driver.SetVehicle(vehicle);
        }
    }
}