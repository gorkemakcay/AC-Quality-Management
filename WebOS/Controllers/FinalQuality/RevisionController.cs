using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QM.BussinessLogic.Interface.FinalQualities;
using QM.Common.ViewModels.FinalQualities.RevisionViewModels;

namespace WebOS.Controllers.FinalQuality
{
    public class RevisionController : Controller
    {
        private readonly IRevisionService _RevisionService;

        public RevisionController(IRevisionService revisionService)
        {
            _RevisionService = revisionService;
        }

        [HttpPost]
        public IActionResult AddRevisionJSON(RevisionAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _RevisionService.AddRevision(model);

                var jSonModel = JsonConvert.SerializeObject(model, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Json(jSonModel);
            }
            return Json(null);
        }

        public IActionResult GetRevisionInfo(int revisionId)
        {
            var jSonModel = JsonConvert.SerializeObject(_RevisionService.GetRevisionInfo(revisionId), new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(jSonModel);
        }

        [HttpPost]
        public IActionResult UpdateRevisionJSON(RevisionUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _RevisionService.UpdateRevision(model);

                var jSonModel = JsonConvert.SerializeObject(model, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Json(jSonModel);
            }
            return Json(null);
        }
    }
}