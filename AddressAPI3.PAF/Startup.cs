using AddressAPI3.Application.Address;
using AddressAPI3.Application.User;
using AddressAPI3.Common.Mail;
using AddressAPI3.EFData;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NLog.Extensions.Logging;
using System.Text;

namespace AddressAPI3.API
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var efConnectionString = Configuration.GetConnectionString("EFConnection");
            var azureConnectionString = Configuration.GetConnectionString("AzureStorageConnection");
            var mailTo = Configuration["MailSettings:mailTo"];

            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                            .AllowAnyMethod()
                                                                            .AllowAnyHeader()));

            // STRONGLY TYPED SETTINGS OBJECTS
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // JWT AUTHENTICATION
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            // CONTEXT
            services.AddDbContext<AddressContext>(o => o.UseSqlServer(efConnectionString));

            // DI
            services.AddTransient<IMailService, MockMailService>(serviceProvider => new MockMailService(mailTo));
            services.AddScoped<IUserRepository, MockUserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAddressRepository, EFAddressRepository>();
            //services.AddScoped<IAddressRepository, AzureAddressRepository>(serviceProvider => new AzureAddressRepository(azureConnectionString));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddNLog();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler();

            app.UseStatusCodePages();

            app.UseCors("AllowAll");

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
