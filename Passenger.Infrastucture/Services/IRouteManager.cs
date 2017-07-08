using System.Threading.Tasks;

namespace Passenger.Infrastucture.Services
{
    public interface IRouteManager: IService
    {
         Task<string> GetAddressAsync(double latitude, double logitude);
         double CalculateDistance(double startLatitude, double startLongitude, 
         double endLatitude, double endLongitude);
    }
}