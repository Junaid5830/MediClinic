using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class ReportDoctorInfoDto
    {
        public int ReportDoctorInfoId { get; set; }
        public string DoctorName { get; set; }
        public string WCBAuthorization { get; set; }
        public string WCBRatingCode { get; set; }
        public string FedralTaxId { get; set; }
        public string TaxIdSSNOrEIN { get; set; }
        public string Address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string BillingGroupOrPractiveName { get; set; }
        public string BillingAddress { get; set; }
        public string Billingcity { get; set; }
        public string BillingState { get; set; }
        public string Billingzip { get; set; }
        public string officePhone { get; set; }
        public string BillingPhone { get; set; }
        public string TreatingProviderNPI { get; set; }
        public string Skill { get; set; }
        public int? VisitId { get; set; }

        public virtual Visits Visit { get; set; }
    }
}
