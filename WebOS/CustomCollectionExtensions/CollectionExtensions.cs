using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using QM.DataAccess.Concrete.EntityFrameworkCore.Context;
using QM.Entities.Concrete;
using QM.Entities.Concrete.Users;
using System;

namespace WebOS.CustomCollectionExtensions
{
    public static class CollectionExtensions
    {
        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt => {
                opt.Password.RequireDigit = false;//sayı içerme zorunluluğu
                opt.Password.RequireUppercase = false;//büyük harf içerme zorunluluğu
                opt.Password.RequiredLength = 1;//uzunluk ayarı
                opt.Password.RequireLowercase = false;//küçük harf içerme zorunluluğu
                opt.Password.RequireNonAlphanumeric = false;// *.! gibi karakter zorunluluğu
            })
            .AddEntityFrameworkStores<ArlentusBIContext>();//Identity'nin çalışacağı veritabanı.

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt => {
                opt.Cookie.Name = "HRCookie";
                opt.Cookie.HttpOnly = true;
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.ExpireTimeSpan = DateTime.Now.Subtract(DateTime.UtcNow).Add(TimeSpan.FromMinutes(25));
                opt.SlidingExpiration = true;
                opt.Cookie.IsEssential = true;
                opt.LoginPath = "/Home/LogIn";
                opt.LogoutPath = "/Home/LogOut";
            });

            services.AddSession(opt =>
            {
                opt.IdleTimeout = DateTime.Now.Subtract(DateTime.UtcNow).Add(TimeSpan.FromMinutes(25));
            });

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "HRCookie";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = DateTime.Now.Subtract(DateTime.UtcNow).Add(TimeSpan.FromMinutes(25));
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/LogIn";
                opt.LogoutPath = "/Home/LogOut";
            });
        }
    }
}
