using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.PatientExamDto;
using MediClinic.Models.DTOs.PrescriptionDto;
using MediClinic.Models.DTOs.ProviderInfoDto;
using MediClinic.Models.DTOs.VitalBasicDto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class PatientExamViewModel
    {
        public ReportExamInfromationDto ExamInfromation { get; set; }

        public List<ReportExamInfromationDto> ExamInfromationList { get; set; }

        public VitalDto VitalDto { get; set; }
        public List<VitalDto> Vitallist { get; set; }

        public List<ProviderInfoBasicDto> ProviderList { get; set; }
        public List<PatientExamReasonDto> PatientExamReasonList { get; set; }
        public GrowthChartDto growthChardto { get; set; }
        public List<GrowthChartDto> growthChartList { get; set; }

        public ImmunizationBasicDto immunization { get; set; }
        public List<ImmunizationBasicDto> Listimmunization { get; set; }

        public PrescriptionBasicDto prescriptionBasicDto { get; set; }

        public List<PrescriptionBasicDto> prescriptionBasicsList { get; set; }
        public LabDto labDto { get; set; }
        public List<LabDto> getLabList { get; set; }
        public ImagingDto imagingDto { get; set; }

        public IEnumerable<SelectListItem> MedicineList { set; get; }

        public List<ImagingDto> getImagingDto { get; set; }
        public List<ICDDto> ICDList { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
}
