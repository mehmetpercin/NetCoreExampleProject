using Business.Concrete;
using Business.Interfaces;
using Business.ValidationRules;
using Core.Caching;
using Core.Repository;
using Core.UnitOfWork;
using Data.Caching;
using Data.Concrete;
using Data.Interfaces;
using Data.UnitOfWork;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business.DependencyResolvers
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ICacheService, InMemoryCacheManager>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<ProductAddDtoValidator>();
            });
        }
    }
}
