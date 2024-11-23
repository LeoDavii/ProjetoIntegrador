using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Source.Context;
using Source.Entities;
using Source.Interfaces;
using Source.Options;
using Source.Repositories;
using Source.Services;
using Source.Validators;

namespace Source
{
    public static class DependencyInjection
    {
        public static void AddCustomOptions(this IServiceCollection services)
        {
            services.Configure<DatabaseContextOptions>(options =>
            {
                options.ConnectionString = "Server=postgres;Database=mydb;Port=5432;User Id=postgres;Password=cadastro";
            });

            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<DatabaseContextOptions>>().Value);
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<Product>, ProductValidator>();
        }

        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContextPool<DatabaseContext>((serviceProvider, options) =>
            {
                var dbContextOptions = serviceProvider.GetRequiredService<DatabaseContextOptions>();
                options.UseNpgsql(dbContextOptions.ConnectionString);
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            });

            var context = services.BuildServiceProvider().GetRequiredService<DatabaseContext>();
            var pendingMigrations = context.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
                context.Database.Migrate();
        }

    }
}
