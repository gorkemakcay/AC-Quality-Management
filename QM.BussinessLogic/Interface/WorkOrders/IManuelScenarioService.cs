using QM.Common.ViewModels.WorkOrders.ManuelScenarioViewModels;
using QM.Entities.Concrete.WorkOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.BussinessLogic.Interface.WorkOrders
{
    public interface IManuelScenarioService : IGenericService<ManuelScenario>
    {
        void AddManuelScenario(ManuelScenarioAddViewModel model);
        List<ManuelScenarioListViewModel> GetAllManuelScenarioWithWorkOrder(int workOrderId);
        void UpdateManuelScenario(ManuelScenarioUpdateViewModel model);
    }
}
