using FluentValidation;
using PizzaBraz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode estar vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome não pode estar vazio.")

                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.")

                .MaximumLength(60)
                .WithMessage("O nome pode ter no máximo 60 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O email não pode estar vazio.")

                .NotNull()
                .WithMessage("O email não pode ser nulo.")

                .MinimumLength(10)
                .WithMessage("O email deve ter no mínimo 10 caracteres.")

                .MaximumLength(180)
                .WithMessage("O email pode ter no máximo 180 caracteres")
                
                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("O email informado não é válido.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("A senha não pode estar vazio.")

                .NotNull()
                .WithMessage("A senha não pode ser nulo.")

                .MinimumLength(6)
                .WithMessage("A senha deve ter no mínimo 6 caracteres.")

                .MaximumLength(60)
                .WithMessage("A senha pode ter no máximo 60 caracteres");

            RuleFor(x => x.Role)
                .NotEmpty()
                .WithMessage("O papel não pode estar vazio.")

                .NotNull()
                .WithMessage("O papel não pode ser nulo.")

                .MinimumLength(3)
                .WithMessage("O papel deve ter no mínimo 3 caracteres.")

                .MaximumLength(60)
                .WithMessage("O papel pode ter no máximo 60 caracteres");

        }
    }
}
