using QM.Common.ViewModels.Documents.DocumentViewModels;
using QM.Entities.Concrete.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.BussinessLogic.Interface.Documents
{
    public interface IDocumentService : IGenericService<Document>
    {
        List<DocumentListViewModel> GetAllDocumentById(int formId, string formType);
    }
}
