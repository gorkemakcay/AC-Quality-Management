using AutoMapper;
using QM.BussinessLogic.Interface.WorkOrders;
using QM.Common.ViewModels.WorkOrders.ManuelScenarioViewModels;
using QM.DataAccess.UnitOfWorks.Interface;
using QM.Entities.Concrete.WorkOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.BussinessLogic.Concrete.WorkOrders
{
    public class ManuelScenarioManager : GenericManager<ManuelScenario>, IManuelScenarioService
    {
        private readonly IUnitOfWork _Uow;
        private readonly IMapper _Mapper;
        public ManuelScenarioManager(IUnitOfWork uow, IMapper mapper) : base(uow)
        {
            _Uow = uow;
            _Mapper = mapper;
        }

        public void AddManuelScenario(ManuelScenarioAddViewModel model)
        {
            Add(_Mapper.Map<ManuelScenario>(model));
            _Uow.SaveChange();
        }

        public List<ManuelScenarioListViewModel> GetAllManuelScenarioWithWorkOrder(int workOrderId)
        {
            return _Mapper.Map<List<ManuelScenarioListViewModel>>(GetAll(I => I.WorkOrderId == workOrderId));
        }

        public void UpdateManuelScenario(ManuelScenarioUpdateViewModel model)
        {
            Update(_Mapper.Map<ManuelScenario>(model));
            _Uow.SaveChange();
        }
    }
}