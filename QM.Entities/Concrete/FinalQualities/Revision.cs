using QM.Entities.Interface;
using System;

namespace QM.Entities.Concrete.FinalQualities
{
    public class Revision : ITable
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
        public FinalQuality FinalQuality { get; set; }
    }
}
