using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Lab
    {
        public int LabId { get; set; }
        public DateTime? DateTime { get; set; }
        public string Examiner { get; set; }
        public string TypeOfExam { get; set; }
        public string Results { get; set; }
        public string Report { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdateBy { get; set; }
        public string ReasonForExam { get; set; }
        public int? VisitId { get; set; }

        public virtual Visits Visit { get; set; }
    }
}
