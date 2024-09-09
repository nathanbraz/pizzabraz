using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PizzaBraz.API.ViewModels;
using PizzaBraz.API.ViewModels.User;
using PizzaBraz.Domain.Entities;
using PizzaBraz.Services.DTO;
using PizzaBraz.Services.Interfaces;

namespace PizzaBraz.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel user)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(user);
                userDTO.CreatedAt = DateTime.UtcNow;
                userDTO.UpdateAt = null;

                var userCreated = await _userService.Create(userDTO);

                var userViewModel = _mapper.Map<UserViewModel>(userCreated);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário cadastrado com sucesso.",
                    Success = true,
                    Data = userViewModel
                });
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao cadastrar um usuário.");
            }
        }
    }
}
