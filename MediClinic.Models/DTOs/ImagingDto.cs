using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class ImagingDto
    {
        public int ImagingId { get; set; }
        public long? PatientId { get; set; }
        public DateTime? DateOfImaging { get; set; }
        public TimeSpan? TimmingOfImaging { get; set; }
        public string ReportedBy { get; set; }
        public string TypeOfImage { get; set; }
        public string ReportStatus { get; set; }
        public string ImageFilm { get; set; }
        public string Diagnosis { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdateBy { get; set; }
        public string PatientName { get; set; }
        public int? VisitId { get; set; }

        public virtual PatientInfo Patient { get; set; }
    }
}
