using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastucture.EF;

namespace Passenger.Infrastucture.Repositories
{
    public class SqlUserRepository : IUserRepository, ISqlRepository
    {
        private readonly PassengerContext _context;
        public SqlUserRepository(PassengerContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> BrowseAsync()
        => await _context.Users.ToListAsync();

        public async Task<User> GetAsync(string email)
        => await _context.Users.SingleOrDefaultAsync(x => x.Email == email);

        public async Task<User> GetAsync(Guid id)
        => await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
             _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}