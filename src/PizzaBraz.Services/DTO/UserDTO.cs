using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Services.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public Guid CompanyId { get; set; }

        public UserDTO() { }

        public UserDTO(string name, string email, string password, string role, Guid companyId)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            CompanyId = companyId;
        }
    }
}
