using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QM.BussinessLogic.Interface.Users;
using QM.Entities.Concrete.Users;

namespace WebOS.Controllers.ProcessQuality
{
    public class ProcessQualityController : Controller
    {
        private readonly ILogger<ProcessQualityController> _logger;
        private readonly IAppUserService _AppUserService;
        private readonly UserManager<AppUser> _UserManager;

        public ProcessQualityController(ILogger<ProcessQualityController> logger,
                                        UserManager<AppUser> userManager,
                                        IAppUserService appUserService)
        {
            _logger = logger;
            _AppUserService = appUserService;
            _UserManager = userManager;
        }
        public IActionResult Index()
        {
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
            ViewBag.Department = "" + user.DepartmentName;//Oturum açan kullanıcının departmanı.
            var role = _UserManager.GetRolesAsync(user);
            ViewBag.Role = role.Result[0].ToString();
            return View();
        }
    }
}