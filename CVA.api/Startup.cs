using CVA.api.Configuration;
using CVA.api.Middleware;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace CVA.api
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDependencyInjectionConfiguration(Configuration);
            services.AddDatabaseConfiguration(Configuration);
            services.AddFluentConfiguration();

            services.AddSwaggerGen(c =>
            {
                c.MapType(typeof(TimeSpan), () => new() { Type = "string", Example = new OpenApiString("00:00:00") });
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Covid Vaccine Appointment\r\n",
                    Version = "v1",
                    
                    Description = "COVID-19 vaccine appointment system. Developed in .NET core 6, it allows users to schedule their vaccines, " +
                    "view existing appointments, and receive notifications about their bookings.",
                    Contact = new() { Name = "Luiz Henrique", Url = new Uri("https://github.com/LuizHenriqueFN") },
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Covid Vaccine Appointment v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            //app.UseMiddleware<ApiMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
