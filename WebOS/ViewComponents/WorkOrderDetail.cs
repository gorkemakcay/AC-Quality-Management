using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using QM.BussinessLogic.Interface;
using QM.BussinessLogic.Interface.Notifications;
using QM.BussinessLogic.Interface.Users;
using QM.BussinessLogic.Interface.WorkOrders;
using QM.Entities.Concrete;
using QM.Entities.Concrete.Users;
using System.Linq;

namespace WebOS.ViewComponents
{
    public class WorkOrderDetail : ViewComponent
    {
        private readonly IWorkOrderService _WorkOrderService;
        private readonly IAppUserService _AppUserService;
        private readonly INotificationService _NotificationService;
        private readonly IUserNotificationService _UserNotificationService;

        public WorkOrderDetail(IWorkOrderService workOrderService,
                                   IAppUserService appUserService,
                                   INotificationService notificationService,
                                   IUserNotificationService userNotificationService)
        {
            _WorkOrderService = workOrderService;
            _AppUserService = appUserService;
            _NotificationService = notificationService;
            _UserNotificationService = userNotificationService;
        }

        public IViewComponentResult Invoke(int workOrderId)
        {
            var model = _WorkOrderService.GetWorkOrderInfo(workOrderId);
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
            ViewBag.UserList = new SelectList(_AppUserService.GetAll().ToList(), "Id", "FullName");

            ViewBag.NotifyCount = new SelectList(_UserNotificationService.GetUserNotificationsBll(user.Id).ToList()).Count().ToString();
            ViewBag.NotyList = new SelectList(_UserNotificationService.GetUserNotificationsBll(user.Id).ToList());

            return View("WorkOrderDetail",model);
        }
    }
}
