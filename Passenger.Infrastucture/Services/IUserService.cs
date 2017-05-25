using System.Threading.Tasks;
using Passenger.Infrastucture.DTO;

namespace Passenger.Infrastucture.Services
{
    public interface IUserService
    {
        Task<UserDto> GetAsync(string email);
        Task RegisterAsync(string email, string username, string password);
    }
}