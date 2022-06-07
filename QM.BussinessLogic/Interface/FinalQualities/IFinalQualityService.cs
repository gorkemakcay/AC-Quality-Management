using QM.Common.ViewModels.FinalQualities.FinalQualityViewModels;
using QM.Entities.Concrete.FinalQualities;
using System;
using System.Collections.Generic;

namespace QM.BussinessLogic.Interface.FinalQualities
{
    public interface IFinalQualityService : IGenericService<FinalQuality>
    {
        List<FinalQualityListViewModel> GetAllFinalQuality();
        void AddFinalQuality(FinalQualityAddViewModel model);
        FinalQualityListViewModel GetFinalQualityDetail(int finalQualityId);
        void UpdateFinalQuality(FinalQualityUpdateViewModel model);
        FinalQualityUpdateViewModel GetFinalQualityInfo(int finalQualityId);
        List<FinalQualityListViewModel> GetFinalQuality(int finalQualityId);
        FinalQualityListViewModel GetFinalQualityForPDF(int finalQualityId);
        List<FinalQualityListViewModel> GetFinalQualityCount(string status);
        List<FinalQualityListViewModel> GetFinalQualityCurrentCount(string workOrderNo);
    }
}