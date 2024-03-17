using FluentValidation;
using SistemaEscolar.Application.Dtos.User.Request;

namespace SistemaEscolar.Application.Validators
{
    public class UserValidator : AbstractValidator<UserRequestDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull().WithMessage("El nombre de usuario no puede ser nulo.")
                .NotEmpty().WithMessage("El nombre de usuario no puede estar vacío.");

            RuleFor(x => x.Password)
               .NotNull().WithMessage("La contraseña es obligatoria.")
               .NotEmpty().WithMessage("La contraseña no puede estar vacía.")
               .MinimumLength(6).WithMessage("La contraseña debe contener al menos 6 caracteres.")
               .MaximumLength(25).WithMessage("La contraseña puede contener hasta 25 caracteres como máximo.");
        }
    }
}
