using CVA.Entity.Model;
using CVA.Utils.Messages;
using FluentValidation;

namespace CVA.Validator.Fluent
{
    public class AppointmentValodator : AbstractValidator<AppointmentRegistrationModel>
    {
        public AppointmentValodator()
        {
            RuleFor(a => a.AppointmentDate)
                .NotEmpty().WithMessage(string.Format(BusinessMessages.FieldRequired, "Appointment Date"))
                .Must(BeValidDate).WithMessage(string.Format(BusinessMessages.InvalidField, "Appointment Date"));
            
            RuleFor(a => a.AppointmentTime)
                .NotEmpty().WithMessage(string.Format(BusinessMessages.FieldRequired, "Appointment Time"))
                .Must(BeValidTime).WithMessage(string.Format(BusinessMessages.InvalidField, "Appointment Time"));
            
            RuleFor(a => a.StatusDescription)
                .NotEmpty().WithMessage(string.Format(BusinessMessages.FieldRequired, "Status"));
            
            RuleFor(a => a.PatientId)
                .NotNull().WithMessage(string.Format(BusinessMessages.FieldRequired, "Patient"));
            
        }

        private static bool BeValidDate(DateOnly appointmentDate)
        {
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Today);
            return appointmentDate >= currentDate;
        }

        private static bool BeValidTime(TimeOnly appointmentTime)
        {
            TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
            return appointmentTime > currentTime;
        }
    }
}
