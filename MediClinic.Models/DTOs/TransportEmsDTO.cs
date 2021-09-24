using MediClinic.Models.EntityModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace MediClinic.Models.DTOs
{
    public class TransportBaseEmsDto
    {
        public TransportBaseEmsDto()
        {
            vehicleAttchments = new List<VehicleAttchmentsDto>();
            Attachments = new IFormFile[0];
        }
        public int TransportId { get; set; }
        [Required(ErrorMessage = "Vehicle type is required")]
        
        public int? VehicleTypeId { get; set; }
        public int? VehicleMakeId { get; set; }
        [Required(ErrorMessage = "Vehicle model is required")]
        public int? VehicleModelId { get; set; }
        
        public int? VehicleCapacity { get; set; }
        [Required(ErrorMessage = "Vehicle plate no is required")]
        public string VehicleLicencePlateNo { get; set; }
        [Required(ErrorMessage = "Vehicle registration state is required")]
        public string VehicleRegistrationState { get; set; }
        [Required(ErrorMessage = "Vehicle VIN no is required")]
        public string VehicleVINNo { get; set; }
        public string VehicleColor { get; set; }
        public string VehiclePhoto { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsAssigned { get; set; }
        public DateTime? LicenseIssueDate { get; set; }
        public DateTime? LicenseExpireDate { get; set; }
        public string RegistrationDocuments { get; set; }
        [JsonIgnore]

        public IFormFile File { get; set; }
        public IFormFile[] Attachments { get; set; }

        public List<VehicleAttchmentsDto> vehicleAttchments { get; set; }
    }
    public class TransportEmsDTO : TransportBaseEmsDto
    {
        public virtual VehicleMake VehicleMake { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }
        public virtual VehicleType VehicleType { get; set; }

    }

    public class VehicleAttchmentsDto
    {
        public string Url { get; set; }
    }
}
