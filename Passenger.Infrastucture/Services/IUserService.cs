using Passenger.Infrastucture.DTO;

namespace Passenger.Infrastucture.Services
{
    public interface IUserService
    {
        UserDto Get(string email);
        void Register(string email, string username, string password);
    }
}