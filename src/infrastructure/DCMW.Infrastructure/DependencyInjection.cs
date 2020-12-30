using CommonServiceLocator;
using DCMW.Domain.Abstractions.Repository;
using DCMW.Infrastructure.DAL.Repository;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSingleton<IDeliveryRepository, DeliveryRepository>();
            services.AddSingleton<IDistributorRepository, DistributorRepository>();
            services.AddSingleton<IDoctorRepository, DoctorRepository>();
            services.AddSingleton<IPickingRepository, PickingRepository>();
            services.AddSingleton<IProductsRepository, ProductRepository>();
            services.AddSingleton<IRemaininRepository, RemainingRepository>();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            ServiceLocator.SetLocatorProvider(services.BuildServiceProvider());

            return services;
        }
    }
}
