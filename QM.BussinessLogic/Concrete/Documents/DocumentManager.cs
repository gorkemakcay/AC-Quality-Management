using AutoMapper;
using QM.BussinessLogic.Interface.Documents;
using QM.Common.ViewModels.Documents.DocumentViewModels;
using QM.DataAccess.UnitOfWorks.Interface;
using QM.Entities.Concrete.Documents;
using System;
using System.Collections.Generic;

namespace QM.BussinessLogic.Concrete.Documents
{
    public class DocumentManager : GenericManager<Document>, IDocumentService
    {
        private readonly IUnitOfWork _Uow;
        private readonly IMapper _Mapper;
        public DocumentManager(IUnitOfWork uow, IMapper mapper) : base(uow)
        {
            _Uow = uow;
            _Mapper = mapper;
        }

        List<DocumentListViewModel> IDocumentService.GetAllDocumentById(int formId, string formType)
        {
            return _Mapper.Map<List<DocumentListViewModel>>(GetAll(I => I.FormId == formId && I.FormType == formType));
        }
    }
}