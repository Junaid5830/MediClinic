using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class ReportPlanCareDto
    {
        public int PlanCareId { get; set; }
        public int VisitId { get; set; }
        public string ProposedTreatment { get; set; }
        public string MedicationsPrescribed { get; set; }
        public string MedicationsAdvised { get; set; }
        public string IsMedicationRestrictions { get; set; }
        public string MedicationRestrictions { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfInjury { get; set; }
        public string IsDiagnosticTestsReferrals { get; set; }
        public bool IsCTScan { get; set; }
        public string CTScan { get; set; }
        public bool IsChiropractor { get; set; }
        public string Chiropractor { get; set; }
        public bool IsEMGNCS { get; set; }
        public string EMGNCS { get; set; }
        public bool IsInternistFamilyPhysician { get; set; }
        public string InternistFamilyPhysician { get; set; }
        public bool IsOccupationalTherapist { get; set; }
        public string OccupationalTherapist { get; set; }
        public bool IsMRI { get; set; }
        public string MRI { get; set; }
        public bool IsLab { get; set; }
        public string Lab { get; set; }
        public bool IsPhysicalTherapist { get; set; }
        public string PhysicalTherapist { get; set; }
        public bool IsXRays { get; set; }
        public string XRays { get; set; }
        public bool IsSpecialistIn { get; set; }
        public string SpecialistIn { get; set; }
        public bool IsOtherXRay { get; set; }
        public string OtherXray { get; set; }
        public bool IsOtherSpecialistIn { get; set; }
        public string OtherSpceialistIn { get; set; }
        public bool IsCane { get; set; }
        public bool IsCrutches { get; set; }
        public bool IsOrthotics { get; set; }
        public bool IsWalker { get; set; }
        public bool IsWheelChair { get; set; }
        public bool IsOtherDevice { get; set; }
        public string FollowUpNextAppointment { get; set; }
    }
}
