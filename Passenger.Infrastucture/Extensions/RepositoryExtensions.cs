using System;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastucture.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<Driver> GetOrFailAsync(this IDriverRepository driverRepository, Guid userId)
        {
            var driver = await driverRepository.GetAsync(userId);
            if(driver == null)
            {
                throw new Exception($"Driver with user id: '{userId}' was not found.");
            }

            return driver;
        }

        public static async Task<User> GetOrFailAsync(this IUserRepository userRepository, Guid userId)
        {
            var user = await userRepository.GetAsync(userId);
            if(user == null)
            {
                throw new Exception($"User with id: '{userId}' was not found.");
            }

            return user;
        }        
    }
}