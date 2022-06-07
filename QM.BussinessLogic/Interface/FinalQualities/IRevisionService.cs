using QM.Common.ViewModels.FinalQualities.RevisionViewModels;
using QM.Entities.Concrete.FinalQualities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.BussinessLogic.Interface.FinalQualities
{
    public interface IRevisionService : IGenericService<Revision>
    {
        void AddRevision(RevisionAddViewModel model);
        List<RevisionListViewModel> GetAllRevisions(int qualityId);
        RevisionUpdateViewModel GetRevisionInfo(int revisionId);
        void UpdateRevision(RevisionUpdateViewModel model);
    }
}

