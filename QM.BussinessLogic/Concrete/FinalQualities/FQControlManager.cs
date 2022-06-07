using AutoMapper;
using QM.BussinessLogic.Interface.FinalQualities;
using QM.Common.ViewModels.FinalQualities.FQControlViewModels;
using QM.DataAccess.UnitOfWorks.Interface;
using QM.Entities.Concrete.FinalQualities;
using System;
using System.Collections.Generic;

namespace QM.BussinessLogic.Concrete.FinalQualities
{
    public class FQControlManager : GenericManager<FQControl>, IFQControlService
    {
        private readonly IUnitOfWork _Uow;
        private readonly IMapper _Mapper;
        public FQControlManager(IUnitOfWork uow, IMapper mapper) : base(uow)
        {
            _Uow = uow;
            _Mapper = mapper;
        }

        public void AddFQControl(FQControlAddViewModel model)
        {
            Add(_Mapper.Map<FQControl>(model));
            _Uow.SaveChange();
        }

        public List<FQControlListViewModel> GetAllFQControls(int qualityId)
        {
            return _Mapper.Map<List<FQControlListViewModel>>(GetAll());

        }

        public void UpdateFQControl(FQControlUpdateViewModel model)
        {
            Update(_Mapper.Map<FQControl>(model));
            _Uow.SaveChange();
        }
    }
}
