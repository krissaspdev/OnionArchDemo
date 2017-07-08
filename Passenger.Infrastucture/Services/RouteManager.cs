using System;
using System.Threading.Tasks;

namespace Passenger.Infrastucture.Services
{
    public class RouteManager : IRouteManager
    {
        private static readonly Random Random = new Random(); 
        public double CalculateDistance(double startLatitude, double startLongitude, double endLatitude, double endLongitude)
        => Random.Next(500, 100000);


        public async Task<string> GetAddressAsync(double latitude, double logitude)
        => await Task.FromResult($"Sample address {Random.Next(100)}");
    }
}