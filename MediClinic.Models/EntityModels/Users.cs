using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Users
    {
        public Users()
        {
            CheckInOut = new HashSet<CheckInOut>();
            DMESupplyEquipment = new HashSet<DMESupplyEquipment>();
            Employee = new HashSet<Employee>();
            MessagesFrom = new HashSet<Messages>();
            MessagesTo = new HashSet<Messages>();
            Notifications = new HashSet<Notifications>();
            PatientArbitrationAttorney = new HashSet<PatientArbitrationAttorney>();
            PatientCaseType = new HashSet<PatientCaseType>();
            PatientDisplaySetting = new HashSet<PatientDisplaySetting>();
            PatientEmergencyContact = new HashSet<PatientEmergencyContact>();
            PatientIdAndSignature = new HashSet<PatientIdAndSignature>();
            PatientInfo = new HashSet<PatientInfo>();
            PatientListDisplaySetting = new HashSet<PatientListDisplaySetting>();
            PatientPersonalInjury = new HashSet<PatientPersonalInjury>();
            PatientPhoneNumber = new HashSet<PatientPhoneNumber>();
            PatientRequireFieldsSetting = new HashSet<PatientRequireFieldsSetting>();
            PatientsClaimInfo = new HashSet<PatientsClaimInfo>();
            ProviderInfo = new HashSet<ProviderInfo>();
            ProviderListSettingss = new HashSet<ProviderListSettingss>();
            SecondaryInsurenceProvider = new HashSet<SecondaryInsurenceProvider>();
            TertiaryInsurenceProvider = new HashSet<TertiaryInsurenceProvider>();
            UserLanguage = new HashSet<UserLanguage>();
            UserProfiles = new HashSet<UserProfiles>();
            VehicalsOrEntityInvolved = new HashSet<VehicalsOrEntityInvolved>();
        }

        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? RoleTypeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedById { get; set; }
        public bool IsActive { get; set; }
        public string ConnectionId { get; set; }
        public bool IsClient { get; set; }

        public virtual ICollection<CheckInOut> CheckInOut { get; set; }
        public virtual ICollection<DMESupplyEquipment> DMESupplyEquipment { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Messages> MessagesFrom { get; set; }
        public virtual ICollection<Messages> MessagesTo { get; set; }
        public virtual ICollection<Notifications> Notifications { get; set; }
        public virtual ICollection<PatientArbitrationAttorney> PatientArbitrationAttorney { get; set; }
        public virtual ICollection<PatientCaseType> PatientCaseType { get; set; }
        public virtual ICollection<PatientDisplaySetting> PatientDisplaySetting { get; set; }
        public virtual ICollection<PatientEmergencyContact> PatientEmergencyContact { get; set; }
        public virtual ICollection<PatientIdAndSignature> PatientIdAndSignature { get; set; }
        public virtual ICollection<PatientInfo> PatientInfo { get; set; }
        public virtual ICollection<PatientListDisplaySetting> PatientListDisplaySetting { get; set; }
        public virtual ICollection<PatientPersonalInjury> PatientPersonalInjury { get; set; }
        public virtual ICollection<PatientPhoneNumber> PatientPhoneNumber { get; set; }
        public virtual ICollection<PatientRequireFieldsSetting> PatientRequireFieldsSetting { get; set; }
        public virtual ICollection<PatientsClaimInfo> PatientsClaimInfo { get; set; }
        public virtual ICollection<ProviderInfo> ProviderInfo { get; set; }
        public virtual ICollection<ProviderListSettingss> ProviderListSettingss { get; set; }
        public virtual ICollection<SecondaryInsurenceProvider> SecondaryInsurenceProvider { get; set; }
        public virtual ICollection<TertiaryInsurenceProvider> TertiaryInsurenceProvider { get; set; }
        public virtual ICollection<UserLanguage> UserLanguage { get; set; }
        public virtual ICollection<UserProfiles> UserProfiles { get; set; }
        public virtual ICollection<VehicalsOrEntityInvolved> VehicalsOrEntityInvolved { get; set; }
    }
}
