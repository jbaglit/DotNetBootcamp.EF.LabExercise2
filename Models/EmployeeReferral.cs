﻿using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.LabExercise2.Models
{
    public partial class EmployeeReferral
    {
        public string CEmployeeReferralNo { get; set; }
        public string CEmployeeCode { get; set; }
        public string CCandidateCode { get; set; }

        public virtual ExternalCandidate CCandidateCodeNavigation { get; set; }
        public virtual Employee CEmployeeCodeNavigation { get; set; }
    }
}
