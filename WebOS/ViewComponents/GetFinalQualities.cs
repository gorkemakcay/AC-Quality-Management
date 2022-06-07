using Microsoft.AspNetCore.Mvc;
using QM.BussinessLogic.Interface.FinalQualities;

namespace WebOS.ViewComponents
{
    public class GetFinalQualities : ViewComponent
    {
        private readonly IFinalQualityService _FinalQualityService;

        public GetFinalQualities(IFinalQualityService finalQualityService)
        {
            _FinalQualityService = finalQualityService;
        }

        public IViewComponentResult Invoke()
        {
            var model = _FinalQualityService.GetAllFinalQuality();
            return View("GetAllFinalQualities", model);
        }
    }
}
