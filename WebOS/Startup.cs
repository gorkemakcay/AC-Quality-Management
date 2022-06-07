using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QM.BussinessLogic.DIContainer;
using QM.BussinessLogic.ValidationRules.FluentValidation.Users.AppUserFluentValidation;
using QM.Common.Mapping.AutoMapperProfile;
using QM.DataAccess.Concrete.EntityFrameworkCore.Context;
using QM.DataAccess.DIContainer;
using QM.Entities.Concrete.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webos;
using WebOS.CustomCollectionExtensions;

namespace WebOS
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddContainerWithDependenciesDal();//Dal Dependency Injection ayarlarý. Static class,baðýmlýlýklarý içerisinde bulunduruyor.Biz oluþturduk.
            services.AddContainerWithDependenciesBll();//Bll Dependency Injection ayarlarý. Static class,baðýmlýlýklarý içerisinde bulunduruyor.Biz oluþturduk.
            services.AddDbContext<ArlentusBIContext>();//DB context ayarý.
            services.AddCustomIdentity();//Identity Configurasyonu içeren class.Biz oluþturduk.
            services.AddAutoMapper(typeof(MapProfile));//AutoMapper DI aracýlýðý ile ele alabliriz.
            services.AddCustomValidatorBll();
            services.AddControllersWithViews()//MVC
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>())
                .AddNewtonsoftJson(opt => {
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IWebHostEnvironment env, 
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/Home/StatusCode", "?code={0}");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            IdentityInitializer.SeedData(userManager, roleManager).Wait();
            app.UseStaticFiles();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller=Home}/{action=LogIn}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=LogIn}/{id?}");
            });
        }
    }
}
