using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QM.BussinessLogic.Interface.Users;
using QM.Common.ViewModels.Users.AppRoleViewModels;
using QM.Common.ViewModels.Users.AppUserViewModels;
using QM.Entities.Concrete.Users;
using System.Threading.Tasks;

namespace WebOS.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly IAppUserService _AppUserService;
        private readonly IAppRoleService _AppRoleService;
        private readonly SignInManager<AppUser> _signInManager;
        private IPasswordHasher<AppUser> _passwordHasher;
        private readonly UserManager<AppUser> _UserManager;

        public AccountController(IAppUserService appUserService,
                                 IAppRoleService _appRoleService,
                                 SignInManager<AppUser> signInManager,
                                 UserManager<AppUser> userManager,
                                 IPasswordHasher<AppUser> passwordHash)
        {
            _AppUserService = appUserService;
            _AppRoleService = _appRoleService;
            _signInManager = signInManager;
            _passwordHasher = passwordHash;
            _UserManager = userManager;
        }
        public IActionResult UserList()
        {
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
            ViewBag.Department = "" + user.DepartmentName;//Oturum açan kullanıcının departmanı.
            var role = _UserManager.GetRolesAsync(user);
            ViewBag.Role = role.Result[0].ToString();
            return View(_AppUserService.GetAllUser());
        }

        [HttpPost]
        public async Task<IActionResult> RegisterJSON(AppUserAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _AppUserService.Registration(model);

                var jSonModel = JsonConvert.SerializeObject(model, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Json(jSonModel);
            }
            //return Json(null);

            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
            var role = _UserManager.GetRolesAsync(user);
            ViewBag.Role = role.Result[0].ToString();
            return View(model);
        }

        public IActionResult GetUserInfo(int userId)
        {
            var jSonModel = JsonConvert.SerializeObject(_AppUserService.GetUserInfo(userId), new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(jSonModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserJSONAsync(AppUserUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _AppUserService.UpdateUser(model);

                var jSonModel = JsonConvert.SerializeObject(model, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Json(jSonModel);
            }
            return Json(null);
        }

        public IActionResult RoleList()
        {
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
            ViewBag.Department = "" + user.DepartmentName;//Oturum açan kullanıcının departmanı.
            var role = _UserManager.GetRolesAsync(user);
            ViewBag.Role = role.Result[0].ToString();
            return View(_AppRoleService.GetAllAppRoles());
        }

        /// <summary>
        /// Role ekleme GET methodu.
        /// </summary>
        /// <returns>AppRoleAddViewModel.</returns>
        public IActionResult AddRole()
        {
            TempData["Active"] = "Role";
            return View(new AppRoleAddViewModel());
        }

        /// <summary>
        /// Role ekleme POST-Json methodu.
        /// </summary>
        /// <param name="model">AppRoleAddViewModel.</param>
        /// <returns>Json tipinde AppRoleAddViewModel.</returns>
        [HttpPost]
        public async Task<IActionResult> AddRoleJSON(AppRoleAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _AppRoleService.AddAppRole(model);
                if (result != null && result.Succeeded)
                {
                    var jSonModel = JsonConvert.SerializeObject(model, new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    return Json(jSonModel);
                }
            }
            return Json(null);
        }

        /// <summary>
        /// Rol silme methodu.
        /// </summary>
        /// <param name="model">AppRoleListViewModel</param>
        /// <returns>Json.</returns>
        public IActionResult DeleteRole(AppRoleListViewModel model)
        {
            _AppRoleService.DeleteAppRole(model);
            return Json(null);
        }

        /// <summary>
        /// Rol güncelleme GET methodu.
        /// </summary>
        /// <param name="Id">Rol Id'si.</param>
        /// <returns>AppRoleUpdateViewModel.</returns>
        ///         
        public IActionResult UpdateRole(int Id)
        {
            return View((_AppRoleService.GetAppRoleInfoToUpdate(Id)));
        }

        /// <summary>
        /// Rol güncelleme POST methodu.
        /// </summary>
        /// <param name="model">AppRoleUpdateViewModel.</param>
        /// <returns>AppRoleUpdateViewModel.</returns>
        [HttpPost]
        public async Task<IActionResult> UpdateRoleJson(AppRoleUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _AppRoleService.UpdateAppRole(model);

                var jSonModel = JsonConvert.SerializeObject(model, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Json(jSonModel);
            }
            return Json(null);
        }
        public IActionResult GetRoleInfo(int userId)
        {
            var jSonModel = JsonConvert.SerializeObject(_AppRoleService.GetById(userId), new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(jSonModel);
        }
    }
}
