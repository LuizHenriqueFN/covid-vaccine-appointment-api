using CVA.Entity.Model;
using CVA.Utils.Messages;
using FluentValidation;

namespace CVA.Validator.Fluent
{
    public class PatientValidator : AbstractValidator<PatientRegistrationModel>
    {
        public PatientValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage(string.Format(BusinessMessages.FieldRequired, "Name"))
                .MaximumLength(255).WithMessage(string.Format(BusinessMessages.FieldMaxLength, "Name", 255));

            RuleFor(p => p.BirthDate)
                .NotEmpty().WithMessage(string.Format(BusinessMessages.FieldRequired, "BirthDate"))
                .Must(BeValidBirthDate).WithMessage(string.Format(BusinessMessages.InvalidField, "BirthDate"));
        }

        private static bool BeValidBirthDate(DateTime birthDate)
        {
            return birthDate <= DateTime.Today;
        }
    }
}
