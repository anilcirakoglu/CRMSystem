using CRM.BusinessLayer.Abstract;
using CRM.BusinessLayer.Concrete;
using CRMSystem.DataAccessLayer.Abstract;
using CRMSystem.DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService,CustomerManager>();
            services.AddScoped<ICustomerDal,EfCustomerDal>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDal, EfUserDal>();
        }
    }
}
