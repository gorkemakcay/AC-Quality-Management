using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QM.BussinessLogic.Interface.FinalQualities;
using QM.Entities.Concrete.Users;

namespace WebOS.ViewComponents
{
    public class QualityExplains : ViewComponent
    {
        private readonly IFinalQualityService _FinalQualityService;
        public QualityExplains(IFinalQualityService finalQualityService)
        {
            _FinalQualityService = finalQualityService;
        }

        public IViewComponentResult Invoke(int qualityId)
        {
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
            var model = _FinalQualityService.GetFinalQualityInfo(qualityId);
            return View("QualityExplainsList", model);
        }
    }
}
