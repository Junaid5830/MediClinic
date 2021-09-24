using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.ApiDtos
{
    public class DriverVehicleDetailDto
    {
        public int TransportId { get; set; }
        public string VehicleType { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public int? VehicleCapacity { get; set; }
        public string VehicleLicencePlateNo { get; set; }
        public string VehicleRegistrationState { get; set; }
        public string VehicleVINNo { get; set; }
        public string VehicleColor { get; set; }
        public string VehiclePhoto { get; set; }

        public DateTime? LicenseIssueDate { get; set; }
        public DateTime? LicenseExpireDate { get; set; }
        public int VehicleTypeId { get; set; }
        public int VehicleMakeId { get; set; }
        public int VehicleModelId { get; set; }

        //public List<VehicleAttchmentsDto> vehicleAttchments { get; set; }
        public IEnumerable<string> vehicleAttchments { get; set; }
    }
    public class VehicleAttchmentsDto
    {
        public string Url { get; set; }
    }


}
