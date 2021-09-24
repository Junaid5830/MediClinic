using MediClinic.Models.DTOs.AddNewCaseTypeDto;
using MediClinic.Models.DTOs.ClaimStatus;
using MediClinic.Models.DTOs.EmploymentStatusDto;
using MediClinic.Models.DTOs.EmploymentTitleDto;
using MediClinic.Models.DTOs.IncidentReportStatusDto;
using MediClinic.Models.DTOs.LegalInfolegealStatusDto;
using MediClinic.Models.DTOs.LookupDto;
using MediClinic.Models.DTOs.Nf2StatusDto;
using MediClinic.Models.DTOs.PatientIdandSignatureDto;
using MediClinic.Models.DTOs.PatientIncidentRoleDto;
using MediClinic.Models.DTOs.PatientInfoDto;
using MediClinic.Models.DTOs.PatientLegalStatusDto;
using MediClinic.Models.DTOs.PatientTreatmentStatusDto;
using MediClinic.Models.DTOs.PatientVehiclesDto;
using MediClinic.Models.DTOs.PatientSignatureIdTypeBasicDto;
using System;
using System.Collections.Generic;
using System.Text;
using MediClinic.Models.DTOs.LegalInfoFirmNameDto;
using MediClinic.Models.DTOs.LegalInfoAttorneyNameDto;
using MediClinic.Models.DTOs.PatientLanguageDto;

namespace MediClinic.Models.DTOs.PatientVMDto
{
    public class PatientVMDto
    {
        public PatientVMDto()
        {
            patientInfoList = new List<PatientInfoBasicDto>();
            patientLegalStatusBasicDtoslist = new List<PatientLegalStatusBasicDto>();
            patientTreatmentStatuslist = new List<PatientTreatmentStatusBasicDto>();
            patientVehiclesBasiclist = new List<PatientVehiclesBasicDto>();
            ClaimStatusList = new List<ClaimStatusBasicDto>();
            IncidentReportStatusList = new List<IncidentReportStatusBasicDto>();
            Nf2list = new List<Nf2StatusBasicDto>();
            IncidentList = new List<PatientIncidentRoleBasicDto>();
            prefixs = new List<LookupBasicDto>();
            suffix = new List<LookupBasicDto>();
            gender = new List<LookupBasicDto>();
            maritalStatus = new List<LookupBasicDto>();
            RaceEthnicity = new List<LookupBasicDto>();
            RelationShip = new List<LookupBasicDto>();
            legalInfoLegalStatusList = new List<legalInfoLegalBasicDto>();
            addNewCaseTypeList = new List<AddNewCaseTypeBasicDto>();
            EmploymentStatuslist = new List<EmploymentStatusBasicDto>();
            LegalInfoFirmNamesList = new List<LegalInfoFirmNameBasicDto>();
            LegalInfoAttorneyNamesList = new List<LegalInfoAttorneyNameBasicDto>();
            patientLanguageList = new List<PatientLanguageBasicDto>();
            PatientSignatureIdTypeList = new List<PatientSignatureIdTypeDto>();
        }
        public List<PatientInfoBasicDto> patientInfoList { get; set; }
        //public List<PatientSignatureIdTypeBasicDto> PatientSignatureIdTypeList { get; set; }

        public List<PatientLegalStatusBasicDto> patientLegalStatusBasicDtoslist { get; set; }
        public List<PatientTreatmentStatusBasicDto> patientTreatmentStatuslist { get; set; }

        public List<PatientVehiclesBasicDto> patientVehiclesBasiclist { get; set; }
        public List<ClaimStatusBasicDto> ClaimStatusList { get; set; }
        public List<IncidentReportStatusBasicDto> IncidentReportStatusList { get; set; }

        public List<Nf2StatusBasicDto> Nf2list { get; set; }
        public List<PatientIncidentRoleBasicDto> IncidentList { get; set; }
        public List<LookupBasicDto> prefixs { get; set; }
        public List<LookupBasicDto> suffix { get; set; }
        public List<LookupBasicDto> gender { get; set; }

        public List<LookupBasicDto> maritalStatus { get; set; }

        public List<LookupBasicDto> RaceEthnicity { get; set; }

        public List<LookupBasicDto> RelationShip { get; set; }

        public List<legalInfoLegalBasicDto> legalInfoLegalStatusList { get; set; }
        public List<AddNewCaseTypeBasicDto> addNewCaseTypeList { get; set; }

        public List<EmploymentStatusBasicDto> EmploymentStatuslist { get; set; }

        public List<EmploymentTitleBasicDto> EmploymentTitleList { get; set; }

        public List<LegalInfoFirmNameBasicDto> LegalInfoFirmNamesList { get; set; }
        public List<LegalInfoAttorneyNameBasicDto> LegalInfoAttorneyNamesList { get; set; }
        public List<PatientLanguageBasicDto> patientLanguageList { get; set; }

        public List<PatientSignatureIdTypeDto> PatientSignatureIdTypeList { get; set; }


        //public List<InsuranceProviderNameBasicDto> InsuranceProviderNamesList { get; set; }

        //public List<InsuranceGroupNumberBasicDto> InsuranceGroupNumbersList { get; set; }
    }
}

