using CVA.Validator.Fluent;
using FluentValidation.AspNetCore;

namespace CVA.api.Configuration
{
    public static class FluentConfiguration
    {
        public static void AddFluentConfiguration(this IServiceCollection services)
        {
            services.AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<PatientValidator>());
            services.AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<AppointmentValidator>());
        }
    }
}
