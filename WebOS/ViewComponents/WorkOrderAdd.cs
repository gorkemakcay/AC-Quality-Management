using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QM.Entities.Concrete;
using QM.Entities.Concrete.Users;

namespace WebOS.ViewComponents
{
    public class WorkOrderAdd : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;
            return View("WorkOrderAdd");
        }
    }
}
