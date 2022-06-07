using AutoMapper;
using QM.BussinessLogic.Interface.FinalQualities;
using QM.Common.ViewModels.FinalQualities.FinalQualityViewModels;
using QM.DataAccess.UnitOfWorks.Interface;
using QM.Entities.Concrete.FinalQualities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QM.BussinessLogic.Concrete.FinalQualities
{
    public class FinalQualityManager : GenericManager<FinalQuality>, IFinalQualityService
    {
        private readonly IUnitOfWork _Uow;
        private readonly IMapper _Mapper;

        public FinalQualityManager(IUnitOfWork uow, IMapper mapper) : base(uow)
        {
            _Uow = uow;
            _Mapper = mapper;
        }

        public void AddFinalQuality(FinalQualityAddViewModel model)
        {
            Add(_Mapper.Map<FinalQuality>(model));
            _Uow.SaveChange();
        }

        public List<FinalQualityListViewModel> GetAllFinalQuality()
        {
            return _Mapper.Map<List<FinalQualityListViewModel>>(GetAll());
        }

        public List<FinalQualityListViewModel> GetFinalQuality(int finalQualityId)
        {
            return _Mapper.Map<List<FinalQualityListViewModel>>(GetAll(I => I.Id == finalQualityId, null, "Specifications,Revisions,VisualControllers"));
        }

        public FinalQualityListViewModel GetFinalQualityDetail(int finalQualityId)
        {
            return _Mapper.Map<FinalQualityListViewModel>(GetFirstOrDefault(I => I.Id == finalQualityId, "Specifications"));
        }

        public FinalQualityListViewModel GetFinalQualityForPDF(int finalQualityId)
        {
            return _Mapper.Map<FinalQualityListViewModel>(GetFirstOrDefault(I => I.Id == finalQualityId, "Specifications,Revisions,VisualControllers"));
        }

        public FinalQualityUpdateViewModel GetFinalQualityInfo(int finalQualityId)
        {
            return _Mapper.Map<FinalQualityUpdateViewModel>(GetById(finalQualityId));
        }

        public void UpdateFinalQuality(FinalQualityUpdateViewModel model)
        {
            Update(_Mapper.Map<FinalQuality>(model));
            _Uow.SaveChange();
        }

        public List<FinalQualityListViewModel> GetFinalQualityCount(string status)
        {
            try
            {
                return _Mapper.Map<List<FinalQualityListViewModel>>(GetAll(I => I.Status == status).ToList());
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {

            }
        }

        public List<FinalQualityListViewModel> GetFinalQualityCurrentCount(string workOrderNo)
        {
            return _Mapper.Map<List<FinalQualityListViewModel>>(GetAll(I => I.WorkOrderNo == workOrderNo).ToList());
        }
    }
}