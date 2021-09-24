using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class ReportEmployeeDto
    {
        public int ReportEmployeeId { get; set; }
        public string CompanyOrAgency { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string zip { get; set; }
        public int? VisitId { get; set; }
        public virtual Visits Visit { get; set; }

    }
}
