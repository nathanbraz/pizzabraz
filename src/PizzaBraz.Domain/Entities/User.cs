using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Domain.Entities
{
    public class User : Base
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        protected User() { }

        public User(string name, string email, string password, string role, Guid companyId, Company company)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            CompanyId = companyId;
            Company = company;
            _errors = new List<string>();
        }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }

        public override bool Validate()
        {
            return true;
        }
    }
}
