using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.LookupDto;
using MediClinic.Models.DTOs.PatientInfoDto;
using MediClinic.Models.DTOs.PatientInfoListDto;
using MediClinic.Models.DTOs.ProviderInfoDto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class PatientsDmePrescriptionsViewModel
    {
        public PatientsDmePrescriptionsViewModel()
        {
            DMEPrescriptionList = new List<DmePatientsPrescriptionDto>();

        }
        public DmePatientsPrescriptionDto DMEPrescription { get; set; }
        public List<DmePatientsPrescriptionDto> DMEPrescriptionList { get; set; }
        public List<DMEGroupItemDto> ItemGroupCptCodeList { get; set; }
        public List<DmeSuppliesManufacturesDto> DmeSuppliesManufacturesList { get; set; }
        public List<ProviderInfoBasicDto> Prescribers { get; set; }
        public List<PatientInfoListDto> Patients { get; set; }
        public List<LookupBasicDto> LookupsList { get; set; }
        public List<SupplierAssignedDmeDto> SupplierList { get; set; }

        public List<BarCode> BarCodeImage { get; set; }
        public List<InsuranceCompaniesDto> InsurenceCompanies { get; set; }
        public ProviderInfoBasicDto Prescriber { get; set; }
        public PatientInfoListDto Patient { get; set; }
        public DmeRentalFormDto DmeRentalFormDto { get; set; }

    }


    public class BarCode
    {
        public string ImageUrl { get; set; }
    }


    public enum ReferenceNo
    {

        [Display(Name = "INITIAL")]
        INITIAL,
        [Display(Name = "POST-OP")]
        POSTOP,
        [Display(Name = "FOLLOW UP")]
        FOLLOWUP,
        [Display(Name = "WELL VISIT")]
        WELLVISIT
    }
}
