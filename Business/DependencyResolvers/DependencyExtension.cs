using Business.Concrete;
using Business.Interfaces;
using Core.UnitOfWork;
using Data.Concrete;
using Data.Interfaces;
using Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
