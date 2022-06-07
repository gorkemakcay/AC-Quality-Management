using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QM.BussinessLogic.Interface.Documents;
using QM.BussinessLogic.Interface.Notifications;
using QM.BussinessLogic.Interface.Users;
using QM.BussinessLogic.Interface.WorkOrders;
using QM.Common.ViewModels.Notifications.NotificationViewModels;
using QM.Common.ViewModels.Notifications.UserNotificationViewModels;
using QM.Common.ViewModels.WorkOrders.ProductViewModels;
using QM.Common.ViewModels.WorkOrders.WorkOrderViewModels;
using QM.Entities.Concrete.Users;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebOS.Controllers.WorkOrder
{
    public class WorkOrderController : Controller
    {
        private readonly IWorkOrderService _WorkOrderService;
        private readonly IProductService _ProductService;
        private readonly IAppUserService _AppUserService;
        private readonly UserManager<AppUser> _UserManager;
        private readonly IDocumentService _DocumentService;
        private readonly INotificationService _NotificationService;
        private readonly IUserNotificationService _UserNotificationService;

        public WorkOrderController(IWorkOrderService workOrderService,
                                   IProductService productService,
                                   UserManager<AppUser> userManager,
                                   IAppUserService appUserService,
                                   IDocumentService documentService,
                                   INotificationService notificationService,
                                   IUserNotificationService userNotificationService)
        {
            _WorkOrderService = workOrderService;
            _ProductService = productService;
            _AppUserService = appUserService;
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

        public IActionResult WorkOrderAllRecords()
        {
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
            ViewBag.Department = "" + user.DepartmentName;//Oturum açan kullanıcının departmanı.
            var role = _UserManager.GetRolesAsync(user);
            ViewBag.Role = role.Result[0].ToString();
            ViewBag.UserList = new SelectList(_AppUserService.GetAll().ToList(), "Id", "FullName");

            ViewBag.NotifyCount = new SelectList(_UserNotificationService.GetUserNotificationsBll(user.Id).ToList()).Count().ToString();
            ViewBag.NotyList = new SelectList(_UserNotificationService.GetUserNotificationsBll(user.Id).ToList());

            ViewBag.AllRecordCount = new SelectList(_WorkOrderService.GetAllWorkOrders().ToList()).Count().ToString();
            ViewBag.WaitingCount = new SelectList(_WorkOrderService.GetWorkOrderCount("planning").ToList()).Count().ToString();
            ViewBag.CountinuesCount = new SelectList(_WorkOrderService.GetWorkOrderCount("continues").ToList()).Count().ToString();
            ViewBag.FinishedCount = new SelectList(_WorkOrderService.GetWorkOrderCount("finish").ToList()).Count().ToString();

            //if (user.Id == 2 || user.Id == 3 || user.Id == 4)
            //{
                return View(_WorkOrderService.GetAllWorkOrders());
            //}
            //else
            //{
            //    return View(_WorkOrderService.GetOwnedWorkOrderBll(user.Id));
            //}
        }

        public IActionResult AddWorkOrders()
        {
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
            ViewBag.Department = "" + user.DepartmentName;//Oturum açan kullanıcının departmanı.
            var role = _UserManager.GetRolesAsync(user);
            ViewBag.Role = role.Result[0].ToString();
            ViewBag.NotifyCount = new SelectList(_UserNotificationService.GetUserNotificationsBll(user.Id).ToList()).Count().ToString();
            ViewBag.NotyList = new SelectList(_UserNotificationService.GetUserNotificationsBll(user.Id).ToList());
            return View();
        }

        [HttpPost]
        public IActionResult AddWorkOrders(WorkOrderAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _WorkOrderService.AddWorkOrder(model);
                var workorder = _WorkOrderService.GetFirstOrDefault(I => I.WorkOrderNo == model.WorkOrderNo);//Eklenen projenin bilgilieri çekildi.

                var projectPersonal = _AppUserService.GetById(workorder.OwnerId);

                var creator = _AppUserService.GetById(workorder.ProjectCreatorId);


                #region Görev bildirimi eklme
                NotificationAddViewModel notificationModel = new NotificationAddViewModel
                {
                    Explain = creator.FullName + ", " + workorder.Company + " firması için " + workorder.WorkOrderNo 
                    + " iş emri numaralı görevi oluşturdu. Proje sorumlusu, " + projectPersonal.FullName + ". Görev başlamadı.",
                    Status = true,
                    WorkOrderId = workorder.Id
                };
                _NotificationService.AddNotification(notificationModel);//Görevin bildirimi eklendi.
                #endregion

                var notification = _NotificationService.GetFirstOrDefault(I => I.Date == notificationModel.Date);//Proje bildiriminin bilgileri çekildi.

                #region Görev sahibi bildirimi.

                UserNotificationAddViewModel ownerNotificationModel = new UserNotificationAddViewModel
                {
                    AppUserId = workorder.OwnerId,
                    NotificationId = notification.Id,
                    Status = true
                };
                _UserNotificationService.AddUserNotification(ownerNotificationModel);//Görev sahibine bildirim eklendi.
                #endregion


                #region Kalite Sorumlusu bildirimi.
                if (workorder.QualityOfficerId != workorder.OwnerId)
                {
                    UserNotificationAddViewModel qualityOffNotificationModel = new UserNotificationAddViewModel
                    {
                        AppUserId = workorder.QualityOfficerId,
                        NotificationId = notification.Id,
                        Status = true
                    };
                    _UserNotificationService.AddUserNotification(qualityOffNotificationModel);//Kalite Sorunlusu bildirim eklendi.
                }
                #endregion

                #region Kalite teknisyeni bildirimi.
                if (workorder.QualityTechnicianId != workorder.OwnerId && workorder.QualityTechnicianId != workorder.QualityOfficerId)
				{
                    UserNotificationAddViewModel qualityTechNotificationModel = new UserNotificationAddViewModel
                    {
                        AppUserId = workorder.QualityTechnicianId,
                        NotificationId = notification.Id,
                        Status = true
                    };
                    _UserNotificationService.AddUserNotification(qualityTechNotificationModel);//Kalite Teknisyeni bildirim eklendi.
                }

				#endregion

				

                var result = SendAsync("Görev ataması " + model.WorkOrderNo, workorder.ProjectCreator.FullName + " sizi, " + workorder.Company + " firması için " + workorder.WorkOrderNo + " iş emri numaralı göreve atadı.");

                var jSonModel = JsonConvert.SerializeObject(model, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Json(workorder.Id);

                
            }



            //return Json(null);
            return View(model);
        }

        public IActionResult WorkOrderDetailInfo(int id)
        {
            var jSonModel = JsonConvert.SerializeObject(_WorkOrderService.GetWorkOrderInfo(id), new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(jSonModel);
        }


        public IActionResult WorkOrderDetail(int id, string formType)
        {
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
            ViewBag.Department = "" + user.DepartmentName;//Oturum açan kullanıcının departmanı.
            var role = _UserManager.GetRolesAsync(user);
            ViewBag.Role = role.Result[0].ToString();
            ViewBag.UserList = new SelectList(_AppUserService.GetAll().ToList(), "Id", "FullName");

            var forWork = _WorkOrderService.GetById(id);

            var projectCreator = _AppUserService.GetById(forWork.ProjectCreatorId);
            ViewBag.ProjectCreator = projectCreator.FullName;

            var projectPersonal = _AppUserService.GetById(forWork.OwnerId);
            ViewBag.ProjectPersonal = projectPersonal.FullName;

            var personal = _AppUserService.GetById(forWork.MontageTechnicianId);
            ViewBag.MontageTechnician = personal.FullName;

            var qualityTechnician = _AppUserService.GetById(forWork.QualityTechnicianId);
            ViewBag.QualityTechnician = qualityTechnician.FullName;

            var qualityOfficer = _AppUserService.GetById(forWork.QualityOfficerId);
            ViewBag.QualityOfficer = qualityOfficer.FullName;

            var model = _ProductService.GetFirstOrDefault(I => I.WorkOrderId == id);
            if (model != null)
            {
                ViewBag.ProductModelName = model.ProductModel;
                ViewBag.ProductNo = model.ProductCode;
                ViewBag.ProductSerialNo = model.ProductSerialCode;
                ViewBag.WorkOrderId = model.WorkOrderId;
                ViewBag.ProductStatus = "OK";
                ViewBag.ProductId = model.Id;
            }
            else
            {
                ViewBag.WorkOrderId = id;
            }

			if (formType == "view")
			{
                ViewBag.openType = "View";
			}

			if (formType == "edit")
			{
                ViewBag.openType = "Edit";
            }
           

            ViewBag.WorkOrderFormType = "WorkOrder";
            ViewBag.WorkOrderDocumentList = _DocumentService.GetAll(I => I.FormId == id && I.FormType == "WorkOrder").ToList();

            ViewBag.NotifyCount = new SelectList(_UserNotificationService.GetUserNotificationsBll(user.Id).ToList()).Count().ToString();
            ViewBag.NotyList = new SelectList(_UserNotificationService.GetUserNotificationsBll(user.Id).ToList());

            return View(_WorkOrderService.GetWorkOrderInfo(id));
        }

        [HttpPost]
        public IActionResult WorkOrderDetail(WorkOrderUpdateViewModel model)
        {
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
            ViewBag.Department = "" + user.DepartmentName;//Oturum açan kullanıcının departmanı.

            ViewBag.NotifyCount = new SelectList(_UserNotificationService.GetUserNotificationsBll(user.Id).ToList()).Count().ToString();
            ViewBag.NotyList = new SelectList(_UserNotificationService.GetUserNotificationsBll(user.Id).ToList());

            var role = _UserManager.GetRolesAsync(user);
            ViewBag.Role = role.Result[0].ToString();
            if (ModelState.IsValid)
            {
                _WorkOrderService.UpdateWorkOrder(model);

                return RedirectToAction("WorkOrderDetail", "WorkOrder", model);
            }
            return View(model);
        }

        public IActionResult AddProducts()
        {
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
            ViewBag.Department = "" + user.DepartmentName;//Oturum açan kullanıcının departmanı.
            var role = _UserManager.GetRolesAsync(user);
            ViewBag.Role = role.Result[0].ToString();
            return View();
        }

        [HttpPost]
        public IActionResult AddProducts(ProductAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _ProductService.AddProduct(model);
                var productInfo = _ProductService.GetFirstOrDefault(I => I.WorkOrderId == model.WorkOrderId);//Eklenen projenin bilgilieri çekildi.

                var jSonModel = JsonConvert.SerializeObject(model, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Json(productInfo.Id);
            }
            //return Json(null);
            return View(model);
        }

        public IActionResult UpdateProducts(int id)
        {
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
            ViewBag.Department = "" + user.DepartmentName;//Oturum açan kullanıcının departmanı.

            ViewBag.NotifyCount = new SelectList(_UserNotificationService.GetUserNotificationsBll(user.Id).ToList()).Count().ToString();
            ViewBag.NotyList = new SelectList(_UserNotificationService.GetUserNotificationsBll(user.Id).ToList());

            var role = _UserManager.GetRolesAsync(user);
            ViewBag.Role = role.Result[0].ToString();
            ViewBag.UserList = new SelectList(_AppUserService.GetAll().ToList(), "Id", "FullName");
            return View(_ProductService.GetProductInfoWithWorkOrder(id));
        }

        [HttpPost]
        public IActionResult UpdateProducts(ProductUpdateViewModel model)
        {
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
            ViewBag.Department = "" + user.DepartmentName;//Oturum açan kullanıcının departmanı.

            ViewBag.NotifyCount = new SelectList(_UserNotificationService.GetUserNotificationsBll(user.Id).ToList()).Count().ToString();
            ViewBag.NotyList = new SelectList(_UserNotificationService.GetUserNotificationsBll(user.Id).ToList());

            var role = _UserManager.GetRolesAsync(user);
            ViewBag.Role = role.Result[0].ToString();
            if (ModelState.IsValid)
            {
                _ProductService.UpdateProduct(model);
                return RedirectToAction("UpdateProducts", "WorkOrder", model);
            }
            return View(model);
        }

        private static IConfigurationRoot _config
        {
            get
            {
                return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            }
        }


        public static async Task<string> SendAsync(string sbt, string bdy)
        {
            try
            {
                string smtpHost = _config.GetSection("MailingService").GetSection("SmtpHost")?.Value;
                string smtpPort = _config.GetSection("MailingService").GetSection("SmtpPort")?.Value;
                string fromAddress = _config.GetSection("MailingService").GetSection("FromAddress")?.Value;
                string password = _config.GetSection("MailingService").GetSection("Password")?.Value;
                string toAddress = _config.GetSection("MailingService").GetSection("ToAddress")?.Value;

                using (var client = new SmtpClient(smtpHost, int.Parse(smtpPort)))
                {
                    client.UseDefaultCredentials = false;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(fromAddress, password);

                    MailMessage message = new MailMessage();

                    message.From = new System.Net.Mail.MailAddress(fromAddress);
                    message.To.Add(toAddress);
                    message.Body = bdy;
                    message.Subject = sbt;
                    message.IsBodyHtml = true;

                    await Task.Run(() => client.Send(message));
                    return "Başarılı";
                }
            }
            catch (System.Exception ex)
            {

                return ex.Message;
            }
        }
    }
}