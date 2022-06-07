using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.Common.ViewModels.Documents.DocumentViewModels
{
    public class DocumentListViewModel
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
