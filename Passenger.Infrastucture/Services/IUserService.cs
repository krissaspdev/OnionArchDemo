using System.Threading.Tasks;
using Passenger.Infrastucture.DTO;

namespace Passenger.Infrastucture.Services
{
    public interface IUserService :IService
    {
        Task<UserDto> GetAsync(string email);
        Task RegisterAsync(string email, string username, string password);
        Task LoginAsync(string email, string password);
    }
}