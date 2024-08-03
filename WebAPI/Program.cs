using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Core.Utilities.Security.JWT;
using Microsoft.IdentityModel.Tokens;
using Core.Utilities.Security.Encryption;
using Core.DependencyResolvers;
using Core.Utilities.IoC;
using Core.Extensions;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(options =>
            {
                options.RegisterModule(new AutoFacBusinessModule());
            });

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors();

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(options =>
                            {
                                options.TokenValidationParameters = new TokenValidationParameters
                                {
                                    ValidateIssuer = true,
                                    ValidateAudience = true,
                                    ValidateLifetime = true,
                                    ValidIssuer = tokenOptions.Issuer,
                                    ValidAudience = tokenOptions.Audience,
                                    ValidateIssuerSigningKey = true,
                                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                                };
                            });
            builder.Services.AddDependencyResolvers(new ICoreModule[]
           {
                new CoreModule()
           });



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}