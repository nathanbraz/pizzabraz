using AutoMapper;
using PizzaBraz.Core.Exceptions;
using PizzaBraz.Core.Services;
using PizzaBraz.Domain.Entities;
using PizzaBraz.Infra.Interfaces;
using PizzaBraz.Services.DTO;
using PizzaBraz.Services.Interfaces;
using System.Xml.Linq;

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
            var userExists = await _userRepository.GetByEmail(userDTO.Email);

            if (userExists != null)
            {
                throw new DomainException("Já existe um usuário com este email.");
            }

            userDTO.Password = PasswordHasher.HashPassword(userDTO.Password);

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userCreated = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExists = await _userRepository.Get(userDTO.Id);

            if (userExists == null)
            {
                throw new DomainException("Não existe nenhum usuário com o id informado");
            }

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userCreated = await _userRepository.Update(user);

            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task<UserDTO> Get(Guid id)
        {
            var user = await _userRepository.Get(id);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> GetAll()
        {
            var users = await _userRepository.GetAll();

            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task Remove(Guid id)
        {
            await _userRepository.Remove(id);
        }

        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            var user = await _userRepository.SearchByEmail(email);

            return _mapper.Map<List<UserDTO>>(user);
        }

        public async Task<List<UserDTO>> SearchByName(string name)
        {
            var user = await _userRepository.SearchByName(name);

            return _mapper.Map<List<UserDTO>>(user);
        }
    }
}
