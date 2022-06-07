using Microsoft.Extensions.DependencyInjection;
using QM.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using QM.DataAccess.Interface;
using QM.DataAccess.UnitOfWorks.Concrete;
using QM.DataAccess.UnitOfWorks.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.DataAccess.DIContainer
{
    public static class CustomExtensionsDal
    {
        public static void AddContainerWithDependenciesDal(this IServiceCollection services)
        {
            //IGenericDal görünce EfGenericRepository örnekler.
            //IUnitOfWork görünce UnitOfWork örnekler.
            //UnitOfWork içinde interfaceler ve repositoryleri örneklendiği için burada DI yapmaya gerek yok.
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>)).AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
