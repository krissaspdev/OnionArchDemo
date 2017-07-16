using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NLog;

namespace Passenger.Infrastucture.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly IDriverService _driverService;
        private readonly IDriverRouteService _driverRouteService;
        //private readonly ILogger<DataInitializer> _logger;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public DataInitializer(IUserService userService, IDriverService driverService, IDriverRouteService driverRouteService)
        {
            _userService = userService;
            _driverService = driverService;
            _driverRouteService = driverRouteService;
        }

        public async Task SeedAsync()
        {
            Logger.Trace("Initializing data...");
            var tasks = new List<Task>();
            for (var i = 1; i <= 10; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"user{i}";
                tasks.Add(_userService.RegisterAsync(userId, $"user{i}@test.com",
                    username, "secret", "user"));
                Logger.Trace($"Adding user: '{username}'.");
                tasks.Add(_driverService.CreateAsync(userId));
                tasks.Add(_driverService.SetVehicleAsync(userId, "BMW", "i8"));
                Logger.Trace($"Created new driver for: '{username}'.");
                 tasks.Add(_driverRouteService.AddAsync(userId, "Default route",1,1,2,2));
                 tasks.Add(_driverRouteService.AddAsync(userId, "Job route",3,3,5,5));
                Logger.Trace($"Created new routes for: '{username}'.");
            }
            for (var i = 1; i <= 3; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"admin{i}";
                Logger.Trace($"Adding admin: '{username}'.");
                tasks.Add(_userService.RegisterAsync(userId, $"admin{i}@test.com",
                    username, "secret", "admin"));
            }

            await Task.WhenAll(tasks).ContinueWith(t =>
            {
               Logger.Trace("Data was initialized.");
            });
        }
    }
}