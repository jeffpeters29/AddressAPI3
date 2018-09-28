using System;
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
using AddressAPI3.Common.Security;
using AddressAPI3.EFUserData;

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
            var azureConnectionString = Configuration.GetConnectionString("AzureTableConnection");
            var efUserConnectionString = Configuration.GetConnectionString("EFUserConnection");

            var mailTo = Configuration["MailSettings:mailTo"];
            var cosmosUri = Configuration["Cosmos:Uri"];
            var cosmosKey = Configuration["Cosmos:Key"];
            var cosmosDatabase = Configuration["Cosmos:Database"];
            var cosmosCollection = Configuration["Cosmos:Collection"];

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
                        //ClockSkew = TimeSpan.Zero,    // Ian (allows for different times configured on different PC's)
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true         // Sean Wildermuth PL video (checks for expiration of token)
                    };
                });

            // CONTEXT
            services.AddDbContext<AddressContext>(o => o.UseSqlServer(efConnectionString));
            services.AddDbContext<UserContext>(o => o.UseSqlServer(efUserConnectionString));

            // DI
            services.AddTransient<IMailService, MockMailService>(serviceProvider => new MockMailService(mailTo));
            services.AddScoped<IPasswordHashService, PasswordHashService>();
            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAddressService, AddressService>();
            //services.AddScoped<IAddressRepository, EFAddressRepository>();
            //services.AddScoped<IAddressRepository, AzureAddressRepository>(serviceProvider => new AzureAddressRepository(azureConnectionString));
            services.AddScoped<IAddressRepository, CosmosRepository>(serviceProvider => new CosmosRepository(cosmosUri,cosmosKey,cosmosDatabase, cosmosCollection));

            services.AddMvc();

            services.AddMemoryCache();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddNLog();

            if (env.IsDevelopment() || env.IsStaging())
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
