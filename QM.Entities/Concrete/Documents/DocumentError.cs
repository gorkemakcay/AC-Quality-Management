using QM.Entities.Interface;
using System;

namespace QM.Entities.Concrete.Documents
{
    public class DocumentError : ITable
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
