using CVA.Repository;
using CVA.Repository.Interface;
using CVA.Repository.Interface.IRepositories;
using CVA.Repository.Repositories;
using CVA.Service.Interface.IServices;
using CVA.Service.Services;

namespace CVA.api.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuracao)
        {
            InjectRepository(services);
            InjectService(services);

            services.AddScoped<ITransactionManager, TransactionManager>();
        }

        private static void InjectRepository(IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        }

        private static void InjectService(IServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
        }


    }
}
