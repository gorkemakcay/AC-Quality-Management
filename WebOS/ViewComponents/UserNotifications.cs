using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QM.BussinessLogic.Interface.Notifications;
using QM.Entities.Concrete.Users;

namespace WebOS.ViewComponents
{
    public class UserNotifications : ViewComponent
    {
        private readonly IUserNotificationService _UserNotificationService;

        public UserNotifications(IUserNotificationService userNotificationService)
        {
            _UserNotificationService = userNotificationService;
        }

        /// <summary>
        /// Kullanıcıya ait bildirimler.
        /// </summary>
        /// <returns></returns>
        public IViewComponentResult Invoke()
        {
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));//Oturum açan kullanıcı bilgisi.//Departmana ait projeleri getirir.
            var model = _UserNotificationService.GetUserNotificationsBll(user.Id);//Oturum açan kullanıcıya ait sorunlar.

            return View("UserNotificationList", model);
        }
    }
}
