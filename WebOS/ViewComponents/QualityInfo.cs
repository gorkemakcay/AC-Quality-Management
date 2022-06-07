using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using QM.BussinessLogic.Interface.FinalQualities;
using QM.BussinessLogic.Interface.Users;
using QM.Entities.Concrete.Users;
using System.Linq;

namespace WebOS.ViewComponents
{
    public class QualityInfo : ViewComponent
    {
        private readonly IFinalQualityService _FinalQualityService;
        private readonly IAppUserService _AppUserService;
        public QualityInfo(IFinalQualityService finalQualityService,
                           IAppUserService appUserService)
        {
            _FinalQualityService = finalQualityService;
            _AppUserService = appUserService;
        }

        public IViewComponentResult Invoke(int qualityId)
        {
            var model = _FinalQualityService.GetFinalQualityInfo(qualityId);
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.

            ViewBag.UserList = new SelectList(_AppUserService.GetAll().ToList(), "Id", "FullName");

            return View("QualityTableInfo", model);
        }
    }
}
