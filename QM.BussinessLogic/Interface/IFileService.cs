
using QM.Common.ViewModels.FinalQualities.FinalQualityViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.BussinessLogic.Interface
{
    public interface IFileService
    {
        byte[] GenerateExcel<T>(List<T> list) where T : class, new();

        string GeneratePDF(string html);

        string GeneratePDF<T>(List<T> list) where T : class, new();

        string GeneratePDF(FinalQualityListViewModel model);
    }
}
