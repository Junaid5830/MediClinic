using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class ReportPatientInformationDto
    {
        public int ReportPatientInfoId { get; set; }
        public long? PatientId { get; set; }
        public string SocialSocityNo { get; set; }
        public string PhoneNo { get; set; }
        public string WCBCaseNo { get; set; }
        public string CarrierCaseNo { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string zip { get; set; }
        public DateTime DateOfillnessOrInjury { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string JobDescription { get; set; }
        public string WorkActivitiesDescription { get; set; }
        public string PatientAccountNo { get; set; }
        public int Visits { get; set; }
    }
}
