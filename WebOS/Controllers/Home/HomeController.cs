using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QM.BussinessLogic.Interface;
using QM.BussinessLogic.Interface.Users;
using QM.Common.ViewModels.Users.AppUserViewModels;
using QM.Entities.Concrete;
using QM.Entities.Concrete.Users;
using System.Diagnostics;
using System.Threading.Tasks;
using WebOS.Models;

namespace WebOS.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppUserService _AppUserService;
        private readonly UserManager<AppUser> _UserManager;
        private readonly SignInManager<AppUser> _SignInManager;

        public HomeController(ILogger<HomeController> logger, 
                              IAppUserService appUserService, 
                              UserManager<AppUser> userManager, 
                              SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _AppUserService = appUserService;
            _UserManager = userManager;
            _SignInManager = signInManager;
        }

        public IActionResult Index()
        {
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
            ViewBag.Department = "" + user.DepartmentName;//Oturum açan kullanıcının departmanı.

            ViewData["LoginUserId"] = user.Id;
            ViewData["LoginUserFullName"] = user.FullName;
            ViewData["Department"] = user.DepartmentName;
            ViewData["Gender"] = user.Gender;


            var role = _UserManager.GetRolesAsync(user);
            ViewBag.Role = role.Result[0].ToString();
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(AppUserLogInViewModel model)
        {
            if (model.UserName != null && ModelState.IsValid)
            {
                var result = await _AppUserService.LogIn(model);
                if (result != null)
                {
                    var user = _UserManager.FindByNameAsync(model.UserName).Result;//Oturum açan kullanıcı bilgisi.
                    HttpContext.Session.SetString("LoginUser", JsonConvert.SerializeObject(user));
                    return RedirectToAction("WorkOrderAllRecords", "WorkOrder");
                }
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış!");
            }
            return View("LogIn", model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _SignInManager.SignOutAsync();
            return RedirectToAction("LogIn");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult QualityForm()
        {
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
            ViewBag.Department = "" + user.DepartmentName;//Oturum açan kullanıcının departmanı.
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}