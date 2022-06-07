using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QM.BussinessLogic.Interface.Users;
using QM.Entities.Concrete.Users;

namespace WebOS.Controllers.Targets
{
    public class QualityTargetController : Controller
    {
        private readonly ILogger<QualityTargetController> _logger;
        private readonly IAppUserService _AppUserService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _UserManager;

        public QualityTargetController(ILogger<QualityTargetController> logger,
                                       SignInManager<AppUser> signInManager,
                                       UserManager<AppUser> userManager,
                                       IAppUserService appUserService)
        {
            _logger = logger;
            _AppUserService = appUserService;
            _signInManager = signInManager;
            _UserManager = userManager;
        }

        public ILogger<QualityTargetController> Logger => _logger;

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
