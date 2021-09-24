using MediClinic.Models.DTOs.ProviderInfoDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.DMESuppliesDto
{
    public class DMESupplieDto
    {
        public int DMEEquipSupId { get; set; }
        [Required(ErrorMessage = "Please Provide Prescription Date")]
        [DataType(DataType.Date)]
        public DateTime? PrescriptionDate { get; set; }
        public long? ICDCodeId { get; set; }
        public long? CPTCodeId { get; set; }
        public long? PrescriberId { get; set; }
        public string Prescriber { get; set; }
        public string BarcodeNo { get; set; }
        public string ImageUrl { get; set; }
        public string ImageUrlHidden { get; set; }
        public bool? IsActive { get; set; }
        public long? PatientId { get; set; }
        public long? UserId { get; set; }
        public int? ItemId { get; set; }
        public string PrescriptionRefNo { get; set; }
        public int? VisitId { get; set; }
        public string QRCodeImage { get; set; }
        public string QRCodeImageUrl { get; set; }


        public List<ICDDto> ICDList { get; set; }
        public List<CPTCodeDto> CPTList { get; set; }
        public List<DMESupEquipItemsDto> DMESupEquipItemsList { get; set; }
        public List<DMESupEquipItemsDto> ItemList { get; set; }
        public List<ProviderInfoBasicDto> PrescriberList { get; set; }
    }

    public class ICDDto
    {
        public long ICDCodeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CPTCodeDto
    {
        public long CPTCodeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class DMESupEquipItemsDto
    {
        public int DMESupEquipId { get; set; }
        public string ItemOrGroupName { get; set; }
    }

    public class CommonFieldsDMECodesDto
    {
        public List<ICDDto> Search { get; set; }
        public List<CPTCodeDto> CPTList { get; set; } 
    }

    public class DMEReferalTemplateDto 
    {
        public string ProviderName { get; set; }
        public string PatientName { get; set; }
        public string ProviderSignature { get; set; }
        public int? ItemId { get; set; }
        public string ItemName { get; set; }
        public List<string> ItemsNames { get; set; }

    }

    public class DMEDeliveryTemplateDto
    {
        public string PatientName { get; set;}
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ProviderName { get; set; }
        public string Comments { get; set; }
        public string PatientGender { get; set; }
    }

    public class DMEAOBDeliveryTemplateDto
    {
        public string Assignor { get; set; }
        public string Assignee { get; set; }
        public DateTime accidentDate{ get; set; }
        public string ProviderName { get; set; }
        public string ProviderSignature { get; set; }
        public string ProviderAddress { get; set; }
        public string ProviderFax { get; set; }
        public string ProviderLicense { get; set; }
        public string ProviderPhone { get; set; }
        public DateTime SignatureDate { get; set; }
        public string PatientName { get; set; }
        public string PatientSignature { get; set; }
        public string PatientAddress { get; set; }
        public string SSN { get; set; }
        public string PatientHomePhone { get; set; }
        public string BusinessPhone { get; set; }
        public string PatientMobilePhone { get; set; }
        public string DIAGNOSIS { get; set; }
        public string PatientDOB { get; set; }
        public string PatientEmergencyPerson { get; set; }
        public string InsuranceProvider { get; set; }
        public string Adjustor { get; set; }
        public string PolicyNo { get; set; }
        public string InsurancePhone { get; set; }
        public string ClaimNumber { get; set; }
        public string ItemName { get; set; }
        public List<string> ItemsNames { get; set; }
    }

    public class DMERxOrderTemplateDto
    {
        public string PatientName { get; set; }
        public string ItemName { get; set; }
        public List<string> ItemsNames { get; set; }

    }

    public class DMESupplyReturnTemplateDto
    {
        public string PatientName { get; set; }
        public string PatientSignature { get; set; }
        public string ItemName { get; set; }
        public List<string> ItemsNames { get; set; }
    }
}
