using Microsoft.AspNetCore.Mvc;

namespace WebOS.ViewComponents
{
    public class QualityDocuments : ViewComponent
    {
        public QualityDocuments()
        {
        }

        public IViewComponentResult Invoke(int qualityId)
        {
            return View("QualityDocumentsList");
        }
    }
}
