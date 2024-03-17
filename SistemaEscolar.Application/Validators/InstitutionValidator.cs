using FluentValidation;
using SistemaEscolar.Application.Dtos.Institution.Request;
using SistemaEscolar.Infrastructure.Persistence.Interfaces;

namespace SistemaEscolar.Application.Validators
{
    public class InstitutionValidator : AbstractValidator<InstitutionRequestDto>
    {
        public InstitutionValidator(IUnitOfWork unitOfWork)
        {            
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El nombre de la institución no puede ser nulo.")
                .NotEmpty().WithMessage("El nombre de la institución no puede estar vacío.")
                .MinimumLength(5).WithMessage("El nombre de la institución debe contener al menos {MinLength} caracteres.")
                .MaximumLength(255).WithMessage("El nombre de la institución puede contener hasta MaxLength} caracteres como máximo.");                

            RuleFor(x => x.Email)
               .NotNull().WithMessage("El e-mail no puede ser nulo.")
               .NotEmpty().WithMessage("El  e-mail no puede estar vacío.")
               .EmailAddress().WithMessage("El texto no tiene el formato válido de una dirección de correo electrónico.")
               .MaximumLength(100).WithMessage("El e-mail puede contener hasta {MaxLength} caracteres como máximo.");               
        }       

    }
}
