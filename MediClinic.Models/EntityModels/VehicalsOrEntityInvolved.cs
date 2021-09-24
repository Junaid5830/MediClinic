using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class VehicalsOrEntityInvolved
    {
        public long PatientVehicleID { get; set; }
        public string VehicleInfo { get; set; }
        public string VehicleLicense { get; set; }
        public string Notes { get; set; }
        public long UserId { get; set; }
        public string VehicleResigrationState { get; set; }
        public int InsuranceProviderId { get; set; }
        public string Vehicle { get; set; }
        public string Role { get; set; }
        public bool? IsDelete { get; set; }

        public virtual InsuranceProviderName InsuranceProvider { get; set; }
        public virtual Users User { get; set; }
    }
}
