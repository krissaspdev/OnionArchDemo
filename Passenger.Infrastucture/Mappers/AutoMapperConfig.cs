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
                cfg.CreateMap<Driver, DriverDto>();
                cfg.CreateMap<Driver, DriverDetailsDto>();
                cfg.CreateMap<Node, NodeDto>();
                cfg.CreateMap<Route, RouteDto>();
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Vehicle, VehicleDto>();
        }).CreateMapper();
    }
}