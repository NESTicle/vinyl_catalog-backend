using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VinylCollection.Data.Models.Base;
using VinylCollection.Data.Models.Mappings.AutoMapper;
using VinylCollection.Service.Implementations;
using VinylCollection.Service.Interfaces;

namespace VinylCollection.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IVinylService, VinylService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommunityService, CommunityService>();
            services.AddScoped<IParameterService, ParameterService>();
            

            // SQL Server Configuration
            services.AddDbContext<VinylDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Db")));
            services.AddAutoMapper(typeof(MappingProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
                 .AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
