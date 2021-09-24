using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class NF2AOBClaim
    {
        public int Nf2AobId { get; set; }
        public string SelfInsuranceName { get; set; }
        public string SelfInsuranceAddress { get; set; }
        public string InsuranceClaimRepresentiveName { get; set; }
        public string InsuranceClaimRepresentiveAddress { get; set; }
        public string PhoneNoOfClaimRepresentive { get; set; }
        public DateTime? Date { get; set; }
        public string PolicyHolder { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime? DateOfIncident { get; set; }
        public string ProviderName { get; set; }
        public string ProviderAddress { get; set; }
        public string PatientName { get; set; }
        public string PatientAddress { get; set; }
        public DateTime? PatientDOB { get; set; }
        public string PatientGender { get; set; }
        public string Occupation { get; set; }
        public string DiagnosisCondition { get; set; }
        public DateTime? SymptomsFirstDate { get; set; }
        public DateTime? ConsutlFirstDate { get; set; }
        public bool EverSmilierCondition { get; set; }
        public string EverSmilerConditionDetail { get; set; }
        public bool ConditionAutoMobileIncident { get; set; }
        public string ConditionAutoMobileIncidentDetail { get; set; }
        public bool IsOutOfPatientEmployment { get; set; }
        public bool? IsDisfiqurementOrPermanentDisablity { get; set; }
        public string DisfiqurementOrPermanentDisablityDetail { get; set; }
        public DateTime? isPatientDisableToWorkFrom { get; set; }
        public DateTime? isPatientDisableToWorkThrough { get; set; }
        public DateTime? ShouldBeAbleToReturnWork { get; set; }
        public bool IsInjurySustainedInIncident { get; set; }
        public string InjurySustainedInIncidentDetail { get; set; }
        public bool IsPatientStillUnderCare { get; set; }
        public DateTime? EstimationReturnOfDuration { get; set; }
        public string PrintNamePatient { get; set; }
        public string PatientSignature { get; set; }
        public DateTime? PrintDate { get; set; }
        public string ProviderPrintName { get; set; }
        public string ProviderSignature { get; set; }
        public DateTime? ProviderDate { get; set; }
        public string AuthorizePrintPatient { get; set; }
        public string AuthorizePatientSign { get; set; }
        public DateTime? AuthorizePatientDate { get; set; }
        public bool IsHasAnOrginalAuthorization { get; set; }
        public bool IsPatientOrginalSignatureOfFiles { get; set; }
        public string AssignorPrintPatientName { get; set; }
        public string AssignorPrintProviderName { get; set; }
        public DateTime? AssignorPrintIncidentName { get; set; }
        public string PrintNameOfPatient { get; set; }
        public string PrintSignatureOfPatient { get; set; }
        public string PrintAddressOfPatient { get; set; }
        public DateTime? PrintDateOfSignaturePatient { get; set; }
        public string PrintNameOfProvider { get; set; }
        public string PrintAddressOfProvider { get; set; }
        public string PrintSignatureOfProvider { get; set; }
        public DateTime? PrintDateOfSignatureProvider { get; set; }
        public int? VisitId { get; set; }
        public int? InsuranceCompanyId { get; set; }

        public virtual InsuranceCompanies InsuranceCompany { get; set; }
    }
}
