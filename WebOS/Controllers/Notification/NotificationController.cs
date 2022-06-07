using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QM.BussinessLogic.Interface.Notifications;
using QM.Common.ViewModels.Notifications.NotificationViewModels;
using System;

namespace WebOS.Controllers.Notification
{
    public class NotificationController : Controller
    {
        private readonly INotificationService _NotificationService;

        public NotificationController(INotificationService notificationService)
        {
            _NotificationService = notificationService;
        }

        [HttpPost]
        public IActionResult AddNotificationJSON(NotificationAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _NotificationService.AddNotification(model);
                var jSonModel = JsonConvert.SerializeObject(model, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Json(jSonModel);
            }
            return View(null);
        }

        public IActionResult GetNotificationJSON(DateTime date)
        {
            var notification = JsonConvert.SerializeObject(_NotificationService.GetFirstOrDefault(I => I.Date == date), new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(notification);
        }
    }
}
