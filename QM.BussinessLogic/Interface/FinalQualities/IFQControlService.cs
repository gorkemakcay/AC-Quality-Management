using QM.Common.ViewModels.FinalQualities.FQControlViewModels;
using QM.Entities.Concrete.FinalQualities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.BussinessLogic.Interface.FinalQualities
{
    public interface IFQControlService : IGenericService<FQControl>
    {
        void AddFQControl(FQControlAddViewModel model);
        void UpdateFQControl(FQControlUpdateViewModel model);
        List<FQControlListViewModel> GetAllFQControls(int qualityId);
    }
}
