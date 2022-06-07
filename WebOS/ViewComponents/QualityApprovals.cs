using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QM.Common.ViewModels.FinalQualities.FinalQualityViewModels;
using QM.Entities.Concrete.Users;

namespace WebOS.ViewComponents
{
    public class QualityApprovals : ViewComponent
    {
        public QualityApprovals()
        {
        }

        public IViewComponentResult Invoke(FinalQualityUpdateViewModel model)
        {
            //var model = _QualityTableService.GetQualityTableInfo(qualityId);
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad+Soyad'.
            return View("QualityApprovalsList", model);
        }
    }
}
