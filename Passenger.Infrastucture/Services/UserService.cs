using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastucture.DTO;
using Passenger.Infrastucture.Exceptions;

namespace Passenger.Infrastucture.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IEncrypter encrypter, IMapper mapper)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> BrowseAsync()
        {
            var users = await _userRepository.BrowseAsync();

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);

            return _mapper.Map<UserDto>(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if(user == null)
            {
                throw new ServiceException(Exceptions.ErrorCodes.InvalidCredentials, "Invalid credentials.");
            }
            
            var hash = _encrypter.GetHash(password, user.Salt);
            if(user.Password == hash)
            {
                return;
            }
            
            throw new ServiceException(Exceptions.ErrorCodes.InvalidCredentials, "Invalid credentials.");
        }

        public async Task RegisterAsync(Guid userId, string email, 
            string username, string password, string role)
        {
            var user = await _userRepository.GetAsync(email);
            if(user != null)
            {
                throw new ServiceException(Exceptions.ErrorCodes.EmailInUse, $"User with email '{email}' already exist.");
            }
            
            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            user = new User(userId, email, username, role, hash, salt);
            await _userRepository.AddAsync(user);
        }
    }
}