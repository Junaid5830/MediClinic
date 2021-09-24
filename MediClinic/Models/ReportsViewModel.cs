using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.ClaimStatus;
using MediClinic.Models.DTOs.IncidentReportStatusDto;
using MediClinic.Models.DTOs.LegalInfoAttorneyNameDto;
using MediClinic.Models.DTOs.Nf2StatusDto;
using MediClinic.Models.DTOs.PatientClaimInfo;
using MediClinic.Models.DTOs.PatientIncidentRoleDto;
using MediClinic.Models.DTOs.PatientInfoListDto;
using MediClinic.Models.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class ReportsViewModel
    {
        public ReportEmployeeDto reportemployeeDto { get; set; }
        public ReportPatientDto reportPatientDto { get; set; }
        public List<PatientInfoListDto> patientListWithUsers { get; set; }
        public ReportExamInfromationDto ExamInfromation { get; set; }
        public ReportPatientInformationDto PatientInformation { get; set; }
        public ReportDoctorOpinionDto DoctorOpinion { get; set; }
        public ReportPlanCareDto PlanOfCare { get; set; }
        public ReportWorkStatusDto WorkStatus { get; set; }

        public IEnumerable<SelectListItem> DropDownListForInuranceCompanies { get; set; }
     

        public ReportBillingInfoDto reportBillingInfoDto { get; set; }
        public ReportBillingCodeDto reportBillingCodeDto { get; set; }
        public ReportDoctorInfoDto reportDoctorInfoDto { get; set; }
        public ReportHistoryDto reportHistoryDto { get; set; }
        public ReportBillingInvoiceDto reportBillingInvoiceDto { get; set; }
        public List<ReportBillingInvoiceDto> reportBillingInvoices { get; set; }
        public NF2AobDto nF2AobDto { get; set; }

        public PatientClaimInfoBasicDto patientClaimInfo { get; set; }

        public CheckInOutDto checkInOutDto { get; set; }

        public List<CheckInOutDto> checkInOutList { get; set; }

        public List<ClaimStatusBasicDto> ClaimStatusList { get; set; }
        public List<Nf2StatusBasicDto> Nf2list { get; set; }
        public List<IncidentReportStatusBasicDto> IncidentReportStatusList { get; set; }
        public List<PatientIncidentRoleBasicDto> IncidentList { get; set; }
        public List<LegalInfoAttorneyNameBasicDto> legalInfoAttorneyNameList { get; set; }

    }
}
