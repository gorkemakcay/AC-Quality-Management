﻿using QM.Entities.Concrete.FinalQualities;
using System;
namespace QM.Common.ViewModels.FinalQualities.RevisionViewModels
{
    public class RevisionAddViewModel
    {
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
