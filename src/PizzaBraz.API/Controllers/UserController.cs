using Microsoft.AspNetCore.Mvc;
using PizzaBraz.API.ViewModels;
using PizzaBraz.Domain.Entities;
using PizzaBraz.Services.DTO;
using PizzaBraz.Services.Interfaces;

namespace PizzaBraz.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody] UserViewModel user)
        {
            try
            {
                var userDTO = new UserDTO
                {
                    //CompanyId = user.CompanyId,
                    Email = user.Email,
                    Name = user.Name,
                    Password = user.Password,
                    Role = user.Role
                };

                var userCreated = await _userService.Create(userDTO);

                return Ok(userCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
