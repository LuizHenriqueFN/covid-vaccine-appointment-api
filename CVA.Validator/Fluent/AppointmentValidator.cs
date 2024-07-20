using CVA.Entity.DTOs;
using CVA.Entity.Model;
using CVA.Utils.Messages;
using FluentValidation;

namespace CVA.Validator.Fluent
{
    public class AppointmentValidator : AbstractValidator<AppointmentRegistrationModel>
    {
        public AppointmentValidator()
        {
            RuleFor(a => a.AppointmentDate)
                .NotEmpty().WithMessage(string.Format(BusinessMessages.FieldRequired, "Appointment Date"))
                .Must(BeValidDate).WithMessage(string.Format(BusinessMessages.InvalidField, "Appointment Date"));

            RuleFor(a => a.AppointmentTime)
                .NotEmpty().WithMessage(string.Format(BusinessMessages.FieldRequired, "Appointment Time"))
                .Must(BeValidTime).WithMessage(string.Format(BusinessMessages.InvalidField, "Appointment Time"));

            RuleFor(a => a.PatientId)
                .NotNull().WithMessage(string.Format(BusinessMessages.FieldRequired, "Patient"));

        }

        private static bool BeValidDate(string appointmentDate)
        {
            if (DateTime.TryParse(appointmentDate, out DateTime parsedDate))
            {
                return parsedDate.Date > DateTime.Now.Date;
            }
            return false;
        }

        private static bool BeValidTime(string appointmentTime)
        {
            if (TimeSpan.TryParse(appointmentTime, out TimeSpan parsedTime))
            {
                return parsedTime > DateTime.Now.TimeOfDay;
            }
            return false;
        }
    }
}
