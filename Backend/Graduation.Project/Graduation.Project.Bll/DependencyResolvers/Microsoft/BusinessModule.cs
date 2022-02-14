using Graduation.Project.Bll.Manager;
using Graduation.Project.Dal.Abstract;
using Graduation.Project.Dal.Concrete.EntityFramework;
using Graduation.Project.Dal.Concrete.EntityFramework.Repository;
using Graduation.Project.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Bll.Mapper.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Bll.DependencyResolvers.Microsoft
{
    public static class BusinessModule
    {

        public static IServiceCollection AddBusinessModule(this IServiceCollection services)
        {
            services.AddDbContext<DbContext, DatabaseContext>();

            #region Service Implementations

            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<IOfferService, OfferManager>();
            services.AddScoped<IPolicyService, PolicyManager>();
            services.AddScoped<IProductService, ProductManager>();

            #endregion

            #region Repository Implementations

            services.AddScoped<ICustomerRepository, EfCustomerRepository>();
            services.AddScoped<IOfferRepository, EfOfferRepository>();
            services.AddScoped<IPolicyRepository, EfPolicyRepository>();
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<IProcedureFunctions, EfProcedureFunctions>();

            #endregion

            services.AddAutoMapper(x =>
            {
                x.AddProfile(new MappingProfile());
            });

            return services;

        }

    }
}
