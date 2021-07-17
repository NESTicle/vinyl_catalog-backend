using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using VinylCollection.Data.Models.Base;
using VinylCollection.Data.Models.Mappings.AutoMapper;
using VinylCollection.Data.Models.Security;
using VinylCollection.Domain.Transversal;
using VinylCollection.Service.Implementations;
using VinylCollection.Service.Interfaces;

namespace VinylCollection.Web
{
    public class Startup
    {
        public readonly string CORS = "VinylCatalog.CORS";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public User User { get; set; } = new User();

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IVinylService, VinylService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommunityService, CommunityService>();
            services.AddScoped<IParameterService, ParameterService>();

            //services.AddScoped<IAppPrincipal, AppPrincipal>();

            // JWT Configuration
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();

                        var userName = context.Principal.Identity.Name;
                        var user = userService.GetUserByUserName(userName);

                        if (user == null)
                            context.Fail("Unauthorized");

                        User.UserName = user.UserName;
                        User.Id = user.Id;

                        return Task.CompletedTask;
                    }
                };

                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetValue<string>("Keys:JWT"))),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddScoped<IAppPrincipal>(provider =>
            {
                if (User != null)
                {
                    var user = provider.GetService<IHttpContextAccessor>()?.HttpContext.User;
                    return new AppPrincipal(User.Id, User.UserName);
                }

                return new AppPrincipal(0, "Unknown");
            });

            // CORS
            services.AddCors(c => c.AddPolicy(CORS, builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            // SQL Server Configuration
            //services.AddDbContext<VinylDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Db")));
            services.AddDbContext<VinylDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("Db")));
            services.AddAutoMapper(typeof(MappingProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(CORS);

            //app.UseHttpsRedirection();
            app.UseRouting();

            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "avatars")),
                RequestPath = "/avatars"
            });
        }
    }
}
