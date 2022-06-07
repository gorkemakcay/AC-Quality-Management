using QM.Entities.Interface;
using System;

namespace QM.Entities.Concrete.Documents
{
    public class Document : ITable
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string FormType { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }
        public string UploadedBy { get; set; }
        public string FilePath { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
