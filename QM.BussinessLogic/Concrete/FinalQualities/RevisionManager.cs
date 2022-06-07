using AutoMapper;
using QM.BussinessLogic.Interface.FinalQualities;
using QM.Common.ViewModels.FinalQualities.RevisionViewModels;
using QM.DataAccess.UnitOfWorks.Interface;
using QM.Entities.Concrete.FinalQualities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.BussinessLogic.Concrete.FinalQualities
{
    public class RevisionManager : GenericManager<Revision>, IRevisionService
    {
        private readonly IUnitOfWork _Uow;
        private readonly IMapper _Mapper;

        public RevisionManager(IUnitOfWork uow, IMapper mapper) : base(uow)
        {
            _Uow = uow;
            _Mapper = mapper;
        }

        public void AddRevision(RevisionAddViewModel model)
        {
            Add(_Mapper.Map<Revision>(model));
            _Uow.SaveChange();
        }

        public List<RevisionListViewModel> GetAllRevisions(int finalQualityId)
        {
            return _Mapper.Map<List<RevisionListViewModel>>(GetAll(I => I.FinalQualityId == finalQualityId));
        }

        public RevisionUpdateViewModel GetRevisionInfo(int revisionId)
        {
            return _Mapper.Map<RevisionUpdateViewModel>(GetById(revisionId));
        }

        public void UpdateRevision(RevisionUpdateViewModel model)
        {
            Update(_Mapper.Map<Revision>(model));
            _Uow.SaveChange();
        }
    }
}