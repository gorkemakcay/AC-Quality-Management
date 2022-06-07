using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QM.BussinessLogic.Interface.Notifications;
using QM.Common.ViewModels.Notifications.UserNotificationViewModels;
using System.Linq;

namespace WebOS.Controllers.Notification
{
    public class UserNotificationController : Controller
    {
        private readonly IUserNotificationService _UserNotificationService;

        public UserNotificationController(IUserNotificationService userNotificationService)
        {
            _UserNotificationService = userNotificationService;
        }
        [HttpPost]
        public IActionResult AddUserNotificationJSON(UserNotificationAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _UserNotificationService.AddUserNotification(model);
                var jSonModel = JsonConvert.SerializeObject(model, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Json(jSonModel);
            }
            return View(null);
        }

        public IActionResult GetUserNotificationCount(int userId, int notificaitonId)
        {
            var notification = JsonConvert.SerializeObject(_UserNotificationService.GetAll(I => I.AppUserId == userId && I.NotificationId == notificaitonId).ToList().Count(), new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(notification);
        }

        public IActionResult DeleteUserNotificationJSON(int notificationId, int userId)
        {
            UserNotificationListViewModel model = new UserNotificationListViewModel
            {
                AppUserId = userId,
                NotificationId = notificationId,
                Status = true
            };
            _UserNotificationService.DeleteUserNotification(model);
            return Json(null);
        }
    }
}
