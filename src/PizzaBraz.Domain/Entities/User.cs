using PizzaBraz.Domain.Validators;
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

        public Guid CompanyId { get; private set; }
        public Company? Company { get; private set; }
        public ICollection<UserRole> UserRoles { get; set; }

        protected User() { }

        public User(string name, string email, string password, string role, Guid companyId)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            CompanyId = companyId;
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
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _errors.Add(error.ErrorMessage);
                }

                throw new Exception("Campos inválidos! " + _errors[0]);
            }

            return true;
        }
    }
}
