using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.ApiDtos
{
    public class UpdateTransportApiDto
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
        public IEnumerable<string> vehicleAttchments { get; set; }

    }
}
