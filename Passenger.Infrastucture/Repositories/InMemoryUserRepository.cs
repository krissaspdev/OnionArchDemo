using System;
using System.Collections.Generic;
using System.Linq;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastucture.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>()
        {
            new User("user1@email.com", "user1","Secret", "Salt"),
            new User("user2@email.com", "user2","Secret", "Salt"),
            new User("user3@email.com", "user3","Secret", "Salt")
        };

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(string email)
        => _users.Single(x => x.Email == email.ToLowerInvariant());

        public User Get(Guid id) => _users.Single(x => x.Id == id);

        public IEnumerable<User> GetAll() => _users;

        public void Remove(Guid id)
        {
            var user = Get(id);
            _users.Remove(user);

        }

        public void Update(User user)
        {

        }
    }
}