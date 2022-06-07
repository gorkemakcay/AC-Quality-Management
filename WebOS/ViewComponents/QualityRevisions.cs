using Microsoft.AspNetCore.Mvc;
using QM.BussinessLogic.Interface;
using QM.BussinessLogic.Interface.FinalQualities;

namespace WebOS.ViewComponents
{
    public class QualityRevisions : ViewComponent
    {
        private readonly IRevisionService _RevisionService;
        public QualityRevisions(IRevisionService revisionService)
        {
            _RevisionService = revisionService;
        }

        public IViewComponentResult Invoke(int qualityId)
        {
            ViewBag.QualityId = qualityId;
            var model = _RevisionService.GetAllRevisions(qualityId);
            return View("QualityRevisionsList", model);
        }
    }
}
