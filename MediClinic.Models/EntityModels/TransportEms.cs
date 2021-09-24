using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class TransportEms
    {
        public TransportEms()
        {
            AmbulanceAssignDriver = new HashSet<AmbulanceAssignDriver>();
            TransportAttachments = new HashSet<TransportAttachments>();
        }

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
        public virtual ICollection<AmbulanceAssignDriver> AmbulanceAssignDriver { get; set; }
        public virtual ICollection<TransportAttachments> TransportAttachments { get; set; }
    }
}
