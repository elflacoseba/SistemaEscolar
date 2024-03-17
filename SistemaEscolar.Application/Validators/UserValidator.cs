using FluentValidation;
using SistemaEscolar.Application.Dtos.User.Request;
using SistemaEscolar.Application.Interfaces;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Infrastructure.Persistence.Interfaces;

namespace SistemaEscolar.Application.Validators
{
    public class UserValidator : AbstractValidator<UserRequestDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.UserName)
                .NotNull().WithMessage("El nombre de usuario no puede ser nulo.")
                .NotEmpty().WithMessage("El nombre de usuario no puede estar vacío.")
                .MinimumLength(5).WithMessage("El Nombre de Usuario debe contener al menos {MinLength} caracteres.")
                .MaximumLength(25).WithMessage("El Nombre de Usuario puede contener hasta MaxLength} caracteres como máximo.")
                .MustAsync(UserNameFree).WithMessage("Ya existe el nombre de usuario.");

            RuleFor(x => x.Password)
               .NotNull().WithMessage("La contraseña es obligatoria.")
               .NotEmpty().WithMessage("La contraseña no puede estar vacía.")
               .MinimumLength(8).WithMessage("La contraseña debe contener al menos {MinLength} caracteres.")
               .MaximumLength(16).WithMessage("La contraseña puede contener hasta {MaxLength} caracteres como máximo.");

            RuleFor(x => x.Email)
               .NotNull().WithMessage("El e-mail no puede ser nulo.")
               .NotEmpty().WithMessage("El  e-mail no puede estar vacío.")
               .EmailAddress().WithMessage("El texto no tiene el formato válido de una dirección de correo electrónico.")
               .MaximumLength(50).WithMessage("El e-mail puede contener hasta {MaxLength} caracteres como máximo.")
               .MustAsync(EmailFree).WithMessage("Ya existe un usuario con el mismo e-mail.");
        }

        /// <summary>
        /// Verifica si el e-mail está libre. (No existe en la base de datos).
        /// </summary>
        /// <param name="email"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        private async Task<bool> EmailFree(string email, CancellationToken token)
        {
            var accountUser = await _unitOfWork.Users.AccountByEmail(email);

            if (accountUser is null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verifica si el nombre de usuario está libre. (No existe en la base de datos).
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        private async Task<bool> UserNameFree(string userName, CancellationToken token)
        {
            var user = await _unitOfWork.Users.AccountByUserName(userName);

            if (user is null)
                return true;
            else
                return false;

        }

    }
}
