using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using QM.BussinessLogic.Interface;
using QM.BussinessLogic.Interface.Documents;
using QM.BussinessLogic.Interface.FinalQualities;
using QM.BussinessLogic.Interface.Notifications;
using QM.BussinessLogic.Interface.Users;
using QM.Common.ViewModels.FinalQualities.FinalQualityViewModels;
using QM.Entities.Concrete;
using QM.Entities.Concrete.Users;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebOS.Controllers.FinalQuality
{
    public class FinalQualityController : Controller
    {

        private readonly IFinalQualityService _FinalQualityService;
        private readonly IAppUserService _AppUserService;
        private readonly IFileService _FileService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _UserManager;
        private readonly IDocumentService _DocumentService;
        private readonly INotificationService _NotificationService;
        private readonly IUserNotificationService _UserNotificationService;

        public FinalQualityController(IFinalQualityService finalQualityService,
                                          IFileService fileService,
                                          IAppUserService appUserService,
                                          SignInManager<AppUser> signInManager,
                                          IDocumentService documentService,
                                          UserManager<AppUser> userManager,
                                          INotificationService notificationService,
                                          IUserNotificationService userNotificationService)
        {

            _FinalQualityService = finalQualityService;
            _FileService = fileService;
            _AppUserService = appUserService;
            _signInManager = signInManager;
            _UserManager = userManager;
            _DocumentService = documentService;
            _NotificationService = notificationService;
            _UserNotificationService = userNotificationService;
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

        public IActionResult AddQualityTable()
        {
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
			ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
			ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
			ViewBag.Department = "" + user.DepartmentName;//Oturum açan kullanıcının departmanı.
			var role = _UserManager.GetRolesAsync(user);
            ViewBag.Role = role.Result[0].ToString();
            return View();
        }

        public IActionResult AllRecords()
        {
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
			ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
			ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
			ViewBag.Department = "" + user.DepartmentName;//Oturum açan kullanıcının departmanı.
			var role = _UserManager.GetRolesAsync(user);
            ViewBag.Role = role.Result[0].ToString();

            ViewBag.AllRecordCount = new SelectList(_FinalQualityService.GetAllFinalQuality().ToList()).Count().ToString();
            ViewBag.WaitingCount = new SelectList(_FinalQualityService.GetFinalQualityCount("Beklemede").ToList()).Count().ToString();
            ViewBag.CountinuesCount = new SelectList(_FinalQualityService.GetFinalQualityCount("Devam").ToList()).Count().ToString();
            ViewBag.FinishedCount = new SelectList(_FinalQualityService.GetFinalQualityCount("Bitti").ToList()).Count().ToString();

            ViewBag.UserList = new SelectList(_AppUserService.GetAll().ToList(), "Id", "FullName");

            ViewBag.NotifyCount = new SelectList(_UserNotificationService.GetUserNotificationsBll(user.Id).ToList()).Count().ToString();
            ViewBag.NotyList = new SelectList(_UserNotificationService.GetUserNotificationsBll(user.Id).ToList());

            return View(_FinalQualityService.GetAllFinalQuality());
        }

        [HttpPost]
        public IActionResult AddQualityTableJSON(FinalQualityAddViewModel model)
        {
            var currentCount = new SelectList(_FinalQualityService.GetFinalQualityCurrentCount(model.WorkOrderNo).ToList()).Count();

            if (ModelState.IsValid && currentCount == 0)
            {
                _FinalQualityService.AddFinalQuality(model);

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
            ViewBag.Department = "" + user.DepartmentName;//Oturum açan kullanıcının departmanı.
            var role = _UserManager.GetRolesAsync(user);
            ViewBag.Role = role.Result[0].ToString();
            return View(model);
        }

        public IActionResult QualityTableDetail(int id)
        {
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
            ViewBag.Department = "" + user.DepartmentName;//Oturum açan kullanıcının departmanı.
            var role = _UserManager.GetRolesAsync(user);
            ViewBag.Role = role.Result[0].ToString();
            return View(_FinalQualityService.GetFinalQualityDetail(id));
        }

        public IActionResult Detail(int id)
        {
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
            ViewBag.Department = "" + user.DepartmentName;//Oturum açan kullanıcının departmanı.
            var role = _UserManager.GetRolesAsync(user);
            ViewBag.Role = role.Result[0].ToString();

            ViewBag.FinalQualityId = id;
            ViewBag.FinalQualityFormType = "FinalQuality";
            ViewBag.FinalQualityDocumentList = _DocumentService.GetAll(I => I.FormId == id && I.FormType == "FinalQuality").ToList();

            var finalQuality = _FinalQualityService.GetById(id);

            //var projectCreator = _AppUserService.GetById(finalQuality.ProjectOwner);
            //ViewBag.ProjectCreator = projectCreator.FullName;

            var projectPersonal = _AppUserService.GetById(Convert.ToInt32(finalQuality.ProjectOwner));
            ViewBag.ProjectPersonal = projectPersonal.FullName;

            var personal = _AppUserService.GetById(Convert.ToInt32(finalQuality.TechnicianName));
            ViewBag.MontageTechnician = personal.FullName;

            var qualityTechnician = _AppUserService.GetById(finalQuality.QualityTechnicianId);
            ViewBag.QualityTechnician = qualityTechnician.FullName;

            var qualityOfficer = _AppUserService.GetById(finalQuality.QualityOfficerId);
            ViewBag.QualityOfficer = qualityOfficer.FullName;

            return View(_FinalQualityService.GetFinalQualityInfo(id));
        }

        [HttpPost]
        public IActionResult Detail(FinalQualityUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
                ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
                ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
                ViewBag.Department = "" + user.DepartmentName;//Oturum açan kullanıcının departmanı.
                var role = _UserManager.GetRolesAsync(user);
                ViewBag.Role = role.Result[0].ToString();
                _FinalQualityService.UpdateFinalQuality(model);
                return RedirectToAction("Detail", "FinalQuality", model);
            }
            return View(model);
        }

        public IActionResult GetExcel(int id)
        {
            var path = _FileService.GenerateExcel(_FinalQualityService.GetFinalQuality(id));
            return File(path, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid() + ".xlsx");
        }

        public IActionResult GetPDF(int id)
        {
            var model = _FinalQualityService.GetFinalQualityForPDF(id);

            string html = "<html>" +
                                "<head>" +
                                    "<meta charset='utf-8'/>" +
                                "</head>" +
                                "<body>" +
                                    "<div id='header'>" +
                                         "<div id='header-logo'>" +
                                            "<img src='~/img/AC.png'/>" +
                                         "</div>" +
                                         "<div id='header-text'>" +
                                            "<h2>FİNAL KALİTE KONTROL FORMU</h2>" +
                                            "<h3>Final Quality Control Form</h3>" +
                                         "</div>" +
                                    "</div>" +
                                    "<div id='quality'>" +
                                        "<div id='customer'>" +
                                            "<div id='customerLabel'>" +
                                                "<h3>Müşteri Adı:</h3>" +
                                            "</div>" +
                                            "<div id='customerName'>" +
                                                " <h3>" + model.Customer + "</h3>" +
                                            "</div>" +
                                        "</div>" +
                                    "</div>" +
                               "</body>" +
                           "</html>";

            var path = _FileService.GeneratePDF(html);
            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }

        public IActionResult Print(int id)
        {
            var model = _FinalQualityService.GetFinalQualityForPDF(id);
            return View(model);
        }
    }
}