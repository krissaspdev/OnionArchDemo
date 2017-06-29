using System.Threading.Tasks;

namespace Passenger.Infrastucture.Services
{
    public interface IDataInitializer: IService
    {
        Task SeedAsync();
    }
}