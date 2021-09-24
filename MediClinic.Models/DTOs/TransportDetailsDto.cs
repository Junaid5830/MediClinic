using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class TransportDetailsDto
    {
        public int TransportId { get; set; }
        public int? VehicleTypeId { get; set; }
        public int? VehicleMakeId { get; set; }
        public int? VehicleModelId { get; set; }
        public int? VehicleCapacity { get; set; }
        public string VehicleLicencePlateNo { get; set; }
        public string VehicleRegistrationState { get; set; }
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

        public virtual VehicleMake VehicleMake { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}
