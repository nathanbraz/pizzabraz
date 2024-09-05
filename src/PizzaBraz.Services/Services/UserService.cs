using AutoMapper;
using PizzaBraz.Core.Services;
using PizzaBraz.Domain.Entities;
using PizzaBraz.Infra.Interfaces;
using PizzaBraz.Services.DTO;
using PizzaBraz.Services.Interfaces;

namespace PizzaBraz.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExists = await _userRepository.Get(userDTO.Id);

            if (userExists != null)
            {
                throw new Exception();
            }

            userDTO.Password = PasswordHasher.HashPassword(userDTO.Password);

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userCreated = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task<UserDTO> Get(Guid id)
        {
            var user = await _userRepository.Get(id);

            if (user != null)
            {
                throw new Exception();
            }

            return _mapper.Map<UserDTO>(user);
        }

        public Task<List<UserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDTO>> SearchByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDTO>> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Update(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
