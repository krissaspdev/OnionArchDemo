using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Infrastucture.DTO;

namespace Passenger.Infrastucture.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        => new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserDto>();
            cfg.CreateMap<Driver, DriverDto>();
        }).CreateMapper();
    }
}