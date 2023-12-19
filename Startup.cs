using Aspekt.Exam.WebApi.DataAccess.Interfaces;
using Aspekt.Exam.WebApi.DataAccess.Repositories;
using Aspekt.Exam.WebApi.Services.Interfaces;
using Aspekt.Exam.WebApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Aspekt.Exam.WebApi.DataContext;

namespace Aspekt.Exam.WebApi
{
    public class Startup
    {
        string connectionString = "Server=localhost.master;Database=AspektDb;Trusted_Connection=False; Encrypt=False";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();



            services.AddDbContext<AspektDbContext>(
                options => options.UseSqlServer(connectionString)
                );

            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();

            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<ICountyService, CountryService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Aspekt.Exam.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aspekt.InterviewApp.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
