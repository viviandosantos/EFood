using EFood.Domain;
using EFood.Domain.Interfaces;
using EFood.Infra.Data.Interfaces;
using EFood.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Products.Infra.Data.Context;

namespace EFood.API.Configurations
{
    public static class ServicesConfig
    {
        public static void AddServicesConfiguration(this IServiceCollection services) 
        {
            services.AddTransient<EFoodContext>();
            
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IPurchaseRepository, PurchaseRepository>();
            services.AddTransient<ISaleRepository, SaleRepository>();

            services.AddTransient<IProductBc, ProductBc>();
            services.AddTransient<IPurchaseBc, PurchaseBc>();
            services.AddTransient<ISaleBc, SaleBc>();
        }
    }
}
