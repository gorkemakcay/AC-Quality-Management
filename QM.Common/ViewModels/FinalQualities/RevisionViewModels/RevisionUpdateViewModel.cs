using System;

namespace QM.Common.ViewModels.FinalQualities.RevisionViewModels
{
    public class RevisionUpdateViewModel
    {
        public int Id { get; set; }
        public DateTime RevisionDate { get; set; }
        public string RevisionExplain { get; set; }
        public string ReasonForRevision { get; set; }
        public string IntendedPurpose { get; set; }
        public string RevisionResult { get; set; }
        public string RevisionType { get; set; }
        public string RevisionRequestedBy { get; set; }
        public int FinalQualityId { get; set; }
    }
}
