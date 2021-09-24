using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ReportWorkStatus
    {
        public int WorkStatusId { get; set; }
        public int VisitId { get; set; }
        public string IsPatientMissedWork { get; set; }
        public DateTime DatePatientMissedWork { get; set; }
        public string IsPatientCurrentlyWorking { get; set; }
        public string IsPatientReturnToWork { get; set; }
        public string PatientCannotReturn { get; set; }
        public DateTime DatePatientCanReturnWithouLimitation { get; set; }
        public DateTime ReturnToWorkCheckAllApplyDate { get; set; }
        public bool IsBendingtwisting { get; set; }
        public bool IsLifting { get; set; }
        public bool IsSitting { get; set; }
        public bool IsLimbingStairsLadders { get; set; }
        public bool IsOperatingHeavyEquipment { get; set; }
        public bool IsStanding { get; set; }
        public bool IsEnvironmentalCondition { get; set; }
        public bool IsOperationOfMotorVehicles { get; set; }
        public bool IsUsePublicTransportation { get; set; }
        public bool IsKneeling { get; set; }
        public bool IsPersonalProtectiveEquipment { get; set; }
        public bool IsUseUpperExtremities { get; set; }
        public bool IsOtherLimitation { get; set; }
        public string OtherLimitation { get; set; }
        public string DescribeQuantifyLimitations { get; set; }
        public string HowLongLimitations { get; set; }
        public string DiscussPatientReturn { get; set; }
        public string IsHealthCareProviderCheck { get; set; }
        public string ProviderName { get; set; }
        public string ProviderSpecialty { get; set; }
        public string Name { get; set; }
        public string Signature { get; set; }
        public string Specialty { get; set; }
        public DateTime Date { get; set; }
    }
}
