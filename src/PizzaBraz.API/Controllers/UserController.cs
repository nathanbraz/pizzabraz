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
                    CompanyId = Guid.Parse("f9974671-adc5-4a50-822c-2218e317d3e4"),
                    Email = user.Email,
                    Name = user.Name,
                    Password = user.Password,
                    Role = user.Role,
                    CreatedAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
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
