using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MediClinic.Models.EntityModels
{
    public partial class Mediclinic_StagingContext : DbContext
    {
        public Mediclinic_StagingContext()
        {
        }

        public Mediclinic_StagingContext(DbContextOptions<Mediclinic_StagingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Allergies> Allergies { get; set; }
        public virtual DbSet<Allergy> Allergy { get; set; }
        public virtual DbSet<AllergyTypes> AllergyTypes { get; set; }
        public virtual DbSet<AssignMenuPageToUsers> AssignMenuPageToUsers { get; set; }
        public virtual DbSet<AssistanInfo> AssistanInfo { get; set; }
        public virtual DbSet<AssistantWorkingSchedule> AssistantWorkingSchedule { get; set; }
        public virtual DbSet<CPTCodes> CPTCodes { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<ClaimStatus> ClaimStatus { get; set; }
        public virtual DbSet<Claims> Claims { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<DME> DME { get; set; }
        public virtual DbSet<DMESupEquipItems> DMESupEquipItems { get; set; }
        public virtual DbSet<DMESupplyEquipment> DMESupplyEquipment { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Disease> Disease { get; set; }
        public virtual DbSet<DoctorPatientTemplate> DoctorPatientTemplate { get; set; }
        public virtual DbSet<DoctorSpeciality> DoctorSpeciality { get; set; }
        public virtual DbSet<DoctorSpecialityLookup> DoctorSpecialityLookup { get; set; }
        public virtual DbSet<DoctorSubSpeciality> DoctorSubSpeciality { get; set; }
        public virtual DbSet<DoctorSubSpecialityLookup> DoctorSubSpecialityLookup { get; set; }
        public virtual DbSet<DoctorTemplate> DoctorTemplate { get; set; }
        public virtual DbSet<DoctorsInfo> DoctorsInfo { get; set; }
        public virtual DbSet<DocumentReports> DocumentReports { get; set; }
        public virtual DbSet<EUO> EUO { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmploymentStatus> EmploymentStatus { get; set; }
        public virtual DbSet<EmploymentTitle> EmploymentTitle { get; set; }
        public virtual DbSet<ExamReason> ExamReason { get; set; }
        public virtual DbSet<ExamType> ExamType { get; set; }
        public virtual DbSet<ICDCodes> ICDCodes { get; set; }
        public virtual DbSet<IME> IME { get; set; }
        public virtual DbSet<Immunization> Immunization { get; set; }
        public virtual DbSet<IncidentReportStatus> IncidentReportStatus { get; set; }
        public virtual DbSet<InsuranceGroupNumber> InsuranceGroupNumber { get; set; }
        public virtual DbSet<InsuranceProviderName> InsuranceProviderName { get; set; }
        public virtual DbSet<InvoiceCharges> InvoiceCharges { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<LegalInfoAttorneyName> LegalInfoAttorneyName { get; set; }
        public virtual DbSet<LegalInfoFirmName> LegalInfoFirmName { get; set; }
        public virtual DbSet<LegalInfoLeadingAttorney> LegalInfoLeadingAttorney { get; set; }
        public virtual DbSet<LegalInfoLeadingParalegal> LegalInfoLeadingParalegal { get; set; }
        public virtual DbSet<LegalInfoLegalStatus> LegalInfoLegalStatus { get; set; }
        public virtual DbSet<Lookups> Lookups { get; set; }
        public virtual DbSet<MHAllergiesHistory> MHAllergiesHistory { get; set; }
        public virtual DbSet<MHDetailPregnanciesHistory> MHDetailPregnanciesHistory { get; set; }
        public virtual DbSet<MHDiseases> MHDiseases { get; set; }
        public virtual DbSet<MHExerciseHistory> MHExerciseHistory { get; set; }
        public virtual DbSet<MHFamilyHistory> MHFamilyHistory { get; set; }
        public virtual DbSet<MHHobbiesHistory> MHHobbiesHistory { get; set; }
        public virtual DbSet<MHHospitalizationsInfo> MHHospitalizationsInfo { get; set; }
        public virtual DbSet<MHMyPhysicians> MHMyPhysicians { get; set; }
        public virtual DbSet<MHPastDiseaseHistory> MHPastDiseaseHistory { get; set; }
        public virtual DbSet<MHPastMedicationHistory> MHPastMedicationHistory { get; set; }
        public virtual DbSet<MHPharmacyInfo> MHPharmacyInfo { get; set; }
        public virtual DbSet<MHPregnanciesHistory> MHPregnanciesHistory { get; set; }
        public virtual DbSet<MHRecreationalDrugsHistory> MHRecreationalDrugsHistory { get; set; }
        public virtual DbSet<MHSocialHistory> MHSocialHistory { get; set; }
        public virtual DbSet<MHSurgicalHistory> MHSurgicalHistory { get; set; }
        public virtual DbSet<MainMenuPages> MainMenuPages { get; set; }
        public virtual DbSet<MedicalDiseaseType> MedicalDiseaseType { get; set; }
        public virtual DbSet<Medicines> Medicines { get; set; }
        public virtual DbSet<MenuPages> MenuPages { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Nf2Status> Nf2Status { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<PackageTransactions> PackageTransactions { get; set; }
        public virtual DbSet<PatientAppointments> PatientAppointments { get; set; }
        public virtual DbSet<PatientArbitrationAttorney> PatientArbitrationAttorney { get; set; }
        public virtual DbSet<PatientCaseType> PatientCaseType { get; set; }
        public virtual DbSet<PatientClinicalNotes> PatientClinicalNotes { get; set; }
        public virtual DbSet<PatientDisplaySetting> PatientDisplaySetting { get; set; }
        public virtual DbSet<PatientEmergencyContact> PatientEmergencyContact { get; set; }
        public virtual DbSet<PatientIdAndSignature> PatientIdAndSignature { get; set; }
        public virtual DbSet<PatientInfo> PatientInfo { get; set; }
        public virtual DbSet<PatientLanguage> PatientLanguage { get; set; }
        public virtual DbSet<PatientLegalStatus> PatientLegalStatus { get; set; }
        public virtual DbSet<PatientListDisplaySetting> PatientListDisplaySetting { get; set; }
        public virtual DbSet<PatientMedicalHistory> PatientMedicalHistory { get; set; }
        public virtual DbSet<PatientMedicalProblem> PatientMedicalProblem { get; set; }
        public virtual DbSet<PatientMedicationsTemplate> PatientMedicationsTemplate { get; set; }
        public virtual DbSet<PatientNewCaseType> PatientNewCaseType { get; set; }
        public virtual DbSet<PatientPersonalInjury> PatientPersonalInjury { get; set; }
        public virtual DbSet<PatientPhoneNumber> PatientPhoneNumber { get; set; }
        public virtual DbSet<PatientPrescriptions> PatientPrescriptions { get; set; }
        public virtual DbSet<PatientPrintSetting> PatientPrintSetting { get; set; }
        public virtual DbSet<PatientRelationship> PatientRelationship { get; set; }
        public virtual DbSet<PatientRequireFieldsSetting> PatientRequireFieldsSetting { get; set; }
        public virtual DbSet<PatientRoleIncident> PatientRoleIncident { get; set; }
        public virtual DbSet<PatientSignatureIdType> PatientSignatureIdType { get; set; }
        public virtual DbSet<PatientTreatmentStatus> PatientTreatmentStatus { get; set; }
        public virtual DbSet<PatientVitals> PatientVitals { get; set; }
        public virtual DbSet<PatientsClaimInfo> PatientsClaimInfo { get; set; }
        public virtual DbSet<Pharmacy> Pharmacy { get; set; }
        public virtual DbSet<PrescriptionTemplates> PrescriptionTemplates { get; set; }
        public virtual DbSet<ProviderInfo> ProviderInfo { get; set; }
        public virtual DbSet<ProviderListSettingss> ProviderListSettingss { get; set; }
        public virtual DbSet<ProviderSessionTypes> ProviderSessionTypes { get; set; }
        public virtual DbSet<ProviderSessions> ProviderSessions { get; set; }
        public virtual DbSet<ProviderSlots> ProviderSlots { get; set; }
        public virtual DbSet<ProviderSpecialities> ProviderSpecialities { get; set; }
        public virtual DbSet<ProviderTemplates> ProviderTemplates { get; set; }
        public virtual DbSet<ProviderTerms> ProviderTerms { get; set; }
        public virtual DbSet<ProviderUIDTypes> ProviderUIDTypes { get; set; }
        public virtual DbSet<ProviderWorkingSchedule> ProviderWorkingSchedule { get; set; }
        public virtual DbSet<RelatedFacilities> RelatedFacilities { get; set; }
        public virtual DbSet<SecondaryInsurenceProvider> SecondaryInsurenceProvider { get; set; }
        public virtual DbSet<SoapNotesSurvey> SoapNotesSurvey { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<SubContractorInfo> SubContractorInfo { get; set; }
        public virtual DbSet<SubProviders> SubProviders { get; set; }
        public virtual DbSet<SubscriptionPackages> SubscriptionPackages { get; set; }
        public virtual DbSet<SurgeryCenter> SurgeryCenter { get; set; }
        public virtual DbSet<Template> Template { get; set; }
        public virtual DbSet<TemplateComponent> TemplateComponent { get; set; }
        public virtual DbSet<TemplateComponentDetail> TemplateComponentDetail { get; set; }
        public virtual DbSet<TertiaryInsurenceProvider> TertiaryInsurenceProvider { get; set; }
        public virtual DbSet<Tests> Tests { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<UserInRoles> UserInRoles { get; set; }
        public virtual DbSet<UserLanguage> UserLanguage { get; set; }
        public virtual DbSet<UserProfiles> UserProfiles { get; set; }
        public virtual DbSet<UserRolePages> UserRolePages { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<VehicalsOrEntityInvolved> VehicalsOrEntityInvolved { get; set; }
        public virtual DbSet<VehicleInsuranceProvider> VehicleInsuranceProvider { get; set; }
        public virtual DbSet<WeekDays> WeekDays { get; set; }
        public virtual DbSet<vw_GetMHHospitalizationsInfo> vw_GetMHHospitalizationsInfo { get; set; }
        public virtual DbSet<vw_GetMHPharmacyInfo> vw_GetMHPharmacyInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=mediclinicsql.database.windows.net;Database=MediClinic_Stg;User Id=mdc; Password=MediclinicKaPass_1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allergies>(entity =>
            {
                entity.HasKey(e => e.AllergyId);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.AllergyType)
                    .WithMany(p => p.Allergies)
                    .HasForeignKey(d => d.AllergyTypeId)
                    .HasConstraintName("FK_Allergies_Allergies");
            });

            modelBuilder.Entity<Allergy>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DateIdentified).HasColumnType("date");

                entity.Property(e => e.DateInactivated).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ExternalProviderId).HasMaxLength(10);

                entity.Property(e => e.Notes).HasMaxLength(1024);

                entity.Property(e => e.Reaction).HasMaxLength(500);
            });

            modelBuilder.Entity<AllergyTypes>(entity =>
            {
                entity.HasKey(e => e.AllergyTypeId);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<AssignMenuPageToUsers>(entity =>
            {
                entity.HasKey(e => e.AssignId)
                    .HasName("PK_AssignMenuPage");

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");

                entity.HasOne(d => d.MenuPage)
                    .WithMany(p => p.AssignMenuPageToUsers)
                    .HasForeignKey(d => d.MenuPageId)
                    .HasConstraintName("FK_AssignMenuPageToUsers_MenuPages");

                entity.HasOne(d => d.RoleType)
                    .WithMany(p => p.AssignMenuPageToUsers)
                    .HasForeignKey(d => d.RoleTypeId)
                    .HasConstraintName("FK_AssignMenuPageToUsers_UserInRoles");
            });

            modelBuilder.Entity<AssistanInfo>(entity =>
            {
                entity.HasKey(e => e.AssistantInfoID);

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.AddressLine2).HasMaxLength(250);

                entity.Property(e => e.AddressLine3).HasMaxLength(250);

                entity.Property(e => e.AssignRoomNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ElectronicSignPassword)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EntityName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FaxNo).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LicenseNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.NpiNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ReminderBy).HasMaxLength(500);

                entity.Property(e => e.RentFee).HasMaxLength(50);

                entity.Property(e => e.SignImage).HasMaxLength(500);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.TaxID).HasMaxLength(50);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AssistantWorkingSchedule>(entity =>
            {
                entity.HasKey(e => e.ScheduleId);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Day)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CPTCodes>(entity =>
            {
                entity.HasKey(e => e.CPTCodeId);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClaimStatus>(entity =>
            {
                entity.Property(e => e.ClaimStatus1)
                    .IsRequired()
                    .HasColumnName("ClaimStatus")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Claims>(entity =>
            {
                entity.HasKey(e => e.Claim_Id);

                entity.Property(e => e.Assistant).HasMaxLength(50);

                entity.Property(e => e.BillDate).HasColumnType("smalldatetime");

                entity.Property(e => e.BillStatus).HasMaxLength(50);

                entity.Property(e => e.CaseType).HasMaxLength(50);

                entity.Property(e => e.DateOfService).HasColumnType("smalldatetime");

                entity.Property(e => e.DescriptionOfService).HasMaxLength(250);

                entity.Property(e => e.DiagnosisCode).HasMaxLength(250);

                entity.Property(e => e.DosFrom).HasColumnType("smalldatetime");

                entity.Property(e => e.DosTo).HasColumnType("smalldatetime");

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DurationOfService).HasColumnType("smalldatetime");

                entity.Property(e => e.FeeSchedule).HasMaxLength(100);

                entity.Property(e => e.OutStandingBalance).HasMaxLength(50);

                entity.Property(e => e.PlaceOfService).HasMaxLength(250);

                entity.Property(e => e.ReferringProvider).HasMaxLength(50);

                entity.Property(e => e.TotalBill).HasMaxLength(50);

                entity.Property(e => e.TrackingNo).HasMaxLength(50);

                entity.Property(e => e.TreatingProvider).HasMaxLength(50);

                entity.Property(e => e.TypeOfService).HasMaxLength(250);

                entity.HasOne(d => d.CPTCodeNavigation)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.CPTCode)
                    .HasConstraintName("FK_claims_CPTCodes");

                entity.HasOne(d => d.ICDCodeNavigation)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.ICDCode)
                    .HasConstraintName("FK_claims_ICDCodes");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Phonecode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sortname)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DME>(entity =>
            {
                entity.Property(e => e.BarcodeNo).HasMaxLength(3);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PrescriptionDate).HasColumnType("datetime");

                entity.HasOne(d => d.CPTCode)
                    .WithMany(p => p.DME)
                    .HasForeignKey(d => d.CPTCodeId)
                    .HasConstraintName("FK_CPTCodesId");

                entity.HasOne(d => d.ICDCode)
                    .WithMany(p => p.DME)
                    .HasForeignKey(d => d.ICDCodeId)
                    .HasConstraintName("FK_ICDCodesId");
            });

            modelBuilder.Entity<DMESupEquipItems>(entity =>
            {
                entity.HasKey(e => e.DMESupEquipId);

                entity.Property(e => e.ItemOrGroupName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DMESupplyEquipment>(entity =>
            {
                entity.HasKey(e => e.DMEEquipSupId);

                entity.Property(e => e.BarcodeNo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl).HasMaxLength(200);

                entity.Property(e => e.PrescriptionDate).HasColumnType("date");

                entity.Property(e => e.PrescriptionRefNo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.CPTCode)
                    .WithMany(p => p.DMESupplyEquipment)
                    .HasForeignKey(d => d.CPTCodeId)
                    .HasConstraintName("FK_DMESupplyEquipment_CPTCodes");

                entity.HasOne(d => d.ICDCode)
                    .WithMany(p => p.DMESupplyEquipment)
                    .HasForeignKey(d => d.ICDCodeId)
                    .HasConstraintName("FK_DMESupplyEquipment_ICDCodes");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.DMESupplyEquipment)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_DMESupplyEquipment_DMESupEquipItems");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.DMESupplyEquipment)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_DMESupplyEquipment_PatientInfo");

                entity.HasOne(d => d.Prescriber)
                    .WithMany(p => p.DMESupplyEquipment)
                    .HasForeignKey(d => d.PrescriberId)
                    .HasConstraintName("FK_DMESupplyEquipment_ProviderInfo");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DMESupplyEquipment)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_DMESupplyEquipment_Users");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<Disease>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<DoctorPatientTemplate>(entity =>
            {
                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.DoctorTemplate)
                    .WithMany(p => p.DoctorPatientTemplate)
                    .HasForeignKey(d => d.DoctorTemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorPatientTemplate_DoctorTemplate");

                entity.HasOne(d => d.TemplateComponent)
                    .WithMany(p => p.DoctorPatientTemplate)
                    .HasForeignKey(d => d.TemplateComponentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorPatientTemplate_TemplateComponent");
            });

            modelBuilder.Entity<DoctorSpeciality>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DoctorSpecialityLookup>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SpecialityName).HasMaxLength(100);
            });

            modelBuilder.Entity<DoctorSubSpeciality>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DoctorSubSpecialityLookup>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SubSpecialityName).HasMaxLength(100);
            });

            modelBuilder.Entity<DoctorTemplate>(entity =>
            {
                entity.HasOne(d => d.Template)
                    .WithMany(p => p.DoctorTemplate)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorTemplate_Template");
            });

            modelBuilder.Entity<DoctorsInfo>(entity =>
            {
                entity.HasKey(e => e.DoctorInfoId);

                entity.Property(e => e.AddressLine1).HasMaxLength(250);

                entity.Property(e => e.AddressLine2).HasMaxLength(250);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.ZIP).HasMaxLength(30);
            });

            modelBuilder.Entity<DocumentReports>(entity =>
            {
                entity.HasKey(e => e.DocumentId);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ScannedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Scannedby).HasMaxLength(50);

                entity.Property(e => e.SourceOfDocument).HasMaxLength(250);
            });

            modelBuilder.Entity<EUO>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Employee_id);

                entity.Property(e => e.Addressline1).HasMaxLength(250);

                entity.Property(e => e.Addressline2).HasMaxLength(250);

                entity.Property(e => e.Addressline3).HasMaxLength(250);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DOB).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.MobNo).HasMaxLength(20);

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(250);

                entity.Property(e => e.ZipCode).HasMaxLength(10);

                entity.HasOne(d => d.EmploymentRole)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.EmploymentRoleId)
                    .HasConstraintName("FK_Employee_UserInRoles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Employee_Users");
            });

            modelBuilder.Entity<EmploymentStatus>(entity =>
            {
                entity.Property(e => e.EmploymentStatus1)
                    .HasColumnName("EmploymentStatus")
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<EmploymentTitle>(entity =>
            {
                entity.Property(e => e.EmploymentTitle1)
                    .HasColumnName("EmploymentTitle")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ExamReason>(entity =>
            {
                entity.Property(e => e.ReasonName).HasMaxLength(200);
            });

            modelBuilder.Entity<ExamType>(entity =>
            {
                entity.Property(e => e.ExamName).HasMaxLength(200);
            });

            modelBuilder.Entity<ICDCodes>(entity =>
            {
                entity.HasKey(e => e.ICDCodeId);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IME>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Immunization>(entity =>
            {
                entity.Property(e => e.DoesInRouten).HasMaxLength(50);

                entity.Property(e => e.ICDCode).HasMaxLength(50);

                entity.Property(e => e.IsCretedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.IsModifiedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PatientCurrentAge).HasColumnType("smalldatetime");

                entity.Property(e => e.Route).HasMaxLength(50);

                entity.Property(e => e.RouteOfAdministration).HasColumnType("smalldatetime");

                entity.Property(e => e.VaccineAbberivation).HasMaxLength(50);

                entity.Property(e => e.VaccineName).HasMaxLength(100);

                entity.HasOne(d => d.PatientInfo)
                    .WithMany(p => p.Immunization)
                    .HasForeignKey(d => d.PatientInfoId)
                    .HasConstraintName("FK_Immunization_PatientInfo");

                entity.HasOne(d => d.ProviderInfo)
                    .WithMany(p => p.Immunization)
                    .HasForeignKey(d => d.ProviderInfoId)
                    .HasConstraintName("FK_Immunization_ProviderInfo");
            });

            modelBuilder.Entity<IncidentReportStatus>(entity =>
            {
                entity.HasKey(e => e.IncidentReportId);

                entity.Property(e => e.IncidentReportStatus1)
                    .IsRequired()
                    .HasColumnName("IncidentReportStatus")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<InsuranceGroupNumber>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.Property(e => e.GroupName).HasMaxLength(50);
            });

            modelBuilder.Entity<InsuranceProviderName>(entity =>
            {
                entity.HasKey(e => e.ProviderId);

                entity.Property(e => e.ProviderName).HasMaxLength(50);
            });

            modelBuilder.Entity<InvoiceCharges>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Product).HasMaxLength(50);

                entity.HasOne(d => d.InvoiceF)
                    .WithMany(p => p.InvoiceCharges)
                    .HasForeignKey(d => d.InvoiceFId);
            });

            modelBuilder.Entity<Invoices>(entity =>
            {
                entity.HasKey(e => e.InvoiceId);

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.MessageOnInvoice).HasMaxLength(50);

                entity.Property(e => e.MessageOnStatement).HasMaxLength(50);

                entity.Property(e => e.MobileNumber).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Terms).HasMaxLength(50);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.PatientId);
            });

            modelBuilder.Entity<Languages>(entity =>
            {
                entity.Property(e => e.Language).HasMaxLength(50);
            });

            modelBuilder.Entity<LegalInfoAttorneyName>(entity =>
            {
                entity.HasKey(e => e.AttorneyId);

                entity.Property(e => e.AttorneyName).HasMaxLength(50);
            });

            modelBuilder.Entity<LegalInfoFirmName>(entity =>
            {
                entity.HasKey(e => e.FirmId);

                entity.Property(e => e.FirmName).HasMaxLength(50);
            });

            modelBuilder.Entity<LegalInfoLeadingAttorney>(entity =>
            {
                entity.HasKey(e => e.LeadingAttorneyId);

                entity.Property(e => e.LeadingAttorneyName).HasMaxLength(50);
            });

            modelBuilder.Entity<LegalInfoLeadingParalegal>(entity =>
            {
                entity.HasKey(e => e.LeadingParalegalId);

                entity.Property(e => e.LeadingParalegalName).HasMaxLength(50);
            });

            modelBuilder.Entity<LegalInfoLegalStatus>(entity =>
            {
                entity.HasKey(e => e.legalStatusId);

                entity.Property(e => e.LegalStatus)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Lookups>(entity =>
            {
                entity.HasKey(e => e.LookupId);

                entity.Property(e => e.LookupType)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LookupValue)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MHAllergiesHistory>(entity =>
            {
                entity.Property(e => e.AllergyTo).HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.Recation).HasMaxLength(50);
            });

            modelBuilder.Entity<MHDetailPregnanciesHistory>(entity =>
            {
                entity.Property(e => e.Complications).HasMaxLength(100);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.DeliveryType).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(20);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MHDiseases>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Disease).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MHExerciseHistory>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Exercise).HasMaxLength(20);

                entity.Property(e => e.ExerciseNoOfDaysPerWeek).HasMaxLength(50);

                entity.Property(e => e.ExerciseType).HasMaxLength(50);

                entity.Property(e => e.HobbiesOrLeisureActivities).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MHFamilyHistory>(entity =>
            {
                entity.Property(e => e.BloodRelativeCondition).HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DeceasedOrDeathAge).HasMaxLength(50);

                entity.Property(e => e.MedicalConditionsOrCauseDeath).HasMaxLength(500);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.Relation).HasMaxLength(20);
            });

            modelBuilder.Entity<MHHobbiesHistory>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Hobbies).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MHHospitalizationsInfo>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.HospitalName).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.illnessORinjury).HasMaxLength(20);
            });

            modelBuilder.Entity<MHMyPhysicians>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Hospital).HasMaxLength(100);

                entity.Property(e => e.Location).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.Specialty).HasMaxLength(50);
            });

            modelBuilder.Entity<MHPastDiseaseHistory>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Notes).HasMaxLength(500);
            });

            modelBuilder.Entity<MHPastMedicationHistory>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DocName).HasMaxLength(50);

                entity.Property(e => e.DocNumber).HasMaxLength(50);

                entity.Property(e => e.Dose).HasMaxLength(50);

                entity.Property(e => e.DoseFrequency).HasMaxLength(20);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.PharName).HasMaxLength(50);

                entity.Property(e => e.PharNumber).HasMaxLength(50);

                entity.Property(e => e.ReasonForMedicine).HasMaxLength(100);
            });

            modelBuilder.Entity<MHPharmacyInfo>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.FaxNo).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(30)
                    .IsFixedLength();
            });

            modelBuilder.Entity<MHPregnanciesHistory>(entity =>
            {
                entity.Property(e => e.BreastExam).HasColumnType("datetime");

                entity.Property(e => e.Contraception).HasMaxLength(20);

                entity.Property(e => e.ContraceptionDetail).HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.GynecologicalConditions).HasMaxLength(100);

                entity.Property(e => e.HotFlashesOrOther).HasMaxLength(100);

                entity.Property(e => e.Mammogram).HasColumnType("datetime");

                entity.Property(e => e.MenstrualPeriods).HasMaxLength(20);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.PapSmear).HasColumnType("datetime");
            });

            modelBuilder.Entity<MHRecreationalDrugsHistory>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Drugs).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RecreationDrugsNotes).HasMaxLength(100);

                entity.Property(e => e.RecreationalDugsType).HasMaxLength(50);
            });

            modelBuilder.Entity<MHSocialHistory>(entity =>
            {
                entity.Property(e => e.Alcohol).HasMaxLength(50);

                entity.Property(e => e.AlcoholNotes).HasMaxLength(100);

                entity.Property(e => e.AlcoholPreferredDrink).HasMaxLength(20);

                entity.Property(e => e.Caffeine).HasMaxLength(20);

                entity.Property(e => e.CaffeineDrinks).HasMaxLength(20);

                entity.Property(e => e.CaffeineNotes).HasMaxLength(100);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Drugs).HasMaxLength(50);

                entity.Property(e => e.Exercise).HasMaxLength(20);

                entity.Property(e => e.ExerciseNoOfDaysPerWeek).HasMaxLength(50);

                entity.Property(e => e.ExerciseType).HasMaxLength(50);

                entity.Property(e => e.HobbiesORLeisureActivities).HasMaxLength(100);

                entity.Property(e => e.LastMonthFeeling).HasMaxLength(20);

                entity.Property(e => e.LastMonthPleasure).HasMaxLength(20);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RecreationalDrugs).HasMaxLength(20);

                entity.Property(e => e.RecreationalDrugsType).HasMaxLength(50);

                entity.Property(e => e.Smoking).HasMaxLength(50);

                entity.Property(e => e.SmokingNotes).HasMaxLength(100);

                entity.Property(e => e.Tobacco).HasMaxLength(20);

                entity.Property(e => e.TobaccoAmountPerDay).HasMaxLength(50);

                entity.Property(e => e.TobaccoType).HasMaxLength(20);
            });

            modelBuilder.Entity<MHSurgicalHistory>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Disease).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.SurgeonName).HasMaxLength(50);

                entity.Property(e => e.SurgeryType).HasMaxLength(50);
            });

            modelBuilder.Entity<MainMenuPages>(entity =>
            {
                entity.HasKey(e => e.MainMenuId);

                entity.Property(e => e.ActionName).HasMaxLength(50);

                entity.Property(e => e.ControllerName).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PageIconPath).HasMaxLength(250);

                entity.Property(e => e.PageName).HasMaxLength(50);
            });

            modelBuilder.Entity<MedicalDiseaseType>(entity =>
            {
                entity.HasKey(e => e.DiseaseTypeId);

                entity.Property(e => e.DiseaseTypeName).HasMaxLength(100);
            });

            modelBuilder.Entity<Medicines>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<MenuPages>(entity =>
            {
                entity.HasKey(e => e.MenuPageId);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PageActionName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PageControllerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PageName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FromUser).HasMaxLength(255);

                entity.Property(e => e.Message).HasMaxLength(4000);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ToUser).HasMaxLength(255);

                entity.HasOne(d => d.From)
                    .WithMany(p => p.MessagesFrom)
                    .HasForeignKey(d => d.FromId)
                    .HasConstraintName("FK_Messages_Users_From");

                entity.HasOne(d => d.To)
                    .WithMany(p => p.MessagesTo)
                    .HasForeignKey(d => d.ToId)
                    .HasConstraintName("FK_Messages_Users_To");
            });

            modelBuilder.Entity<Nf2Status>(entity =>
            {
                entity.HasKey(e => e.Nf2Id);

                entity.Property(e => e.Nf2Status1)
                    .IsRequired()
                    .HasColumnName("Nf2Status")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsRead).HasDefaultValueSql("((0))");

                entity.Property(e => e.NotificationInfo).HasMaxLength(250);

                entity.Property(e => e.NotificationText).HasMaxLength(50);

                entity.Property(e => e.NotificationType).HasMaxLength(50);

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Notifications_PatientAppointments");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Notifications_Users");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserRoleId)
                    .HasConstraintName("FK_Notifications_UserInRoles");
            });

            modelBuilder.Entity<PackageTransactions>(entity =>
            {
                entity.HasKey(e => e.PackageTransactionId);

                entity.Property(e => e.TransactionId).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PackageTransactions)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_PackageTransactions_EmployeeId");
            });

            modelBuilder.Entity<PatientAppointments>(entity =>
            {
                entity.HasKey(e => e.AppointmentId);

                entity.Property(e => e.AppointmentType).HasMaxLength(30);

                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ExactTime).HasColumnType("smalldatetime");

                entity.Property(e => e.IsCompleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.PatientInfo)
                    .WithMany(p => p.PatientAppointments)
                    .HasForeignKey(d => d.PatientInfoId)
                    .HasConstraintName("FK_patientAppointments_PatientInfo");

                entity.HasOne(d => d.ProviderInfo)
                    .WithMany(p => p.PatientAppointments)
                    .HasForeignKey(d => d.ProviderInfoId)
                    .HasConstraintName("FK_PatientAppointments_ProviderInfo");

                entity.HasOne(d => d.Slot)
                    .WithMany(p => p.PatientAppointments)
                    .HasForeignKey(d => d.SlotId)
                    .HasConstraintName("FK_PatientAppointments_ProviderSlots");
            });

            modelBuilder.Entity<PatientArbitrationAttorney>(entity =>
            {
                entity.HasKey(e => e.ArbitrationAttorneyID)
                    .HasName("PK_ArbitrationAttorneyID");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AddressLine2).HasMaxLength(50);

                entity.Property(e => e.AddressLine3).HasMaxLength(50);

                entity.Property(e => e.AttorneyFields).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(20);

                entity.Property(e => e.LeadingAttorneyEmail).HasMaxLength(50);

                entity.Property(e => e.LeadingAttorneyExtension).HasMaxLength(50);

                entity.Property(e => e.LeadingAttorneyFax).HasMaxLength(20);

                entity.Property(e => e.LeadingAttorneyPhone).HasMaxLength(20);

                entity.Property(e => e.LeadingParalegalEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LeadingParalegalExtension).HasMaxLength(50);

                entity.Property(e => e.LeadingParalegalFax).HasMaxLength(50);

                entity.Property(e => e.LeadingParalegalPhone).HasMaxLength(50);

                entity.Property(e => e.LegalStatus).HasMaxLength(20);

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.Website).HasMaxLength(50);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Attorney)
                    .WithMany(p => p.PatientArbitrationAttorney)
                    .HasForeignKey(d => d.AttorneyId)
                    .HasConstraintName("FK_PatientArbitrationAttorney_LegalInfoAttorneyName");

                entity.HasOne(d => d.Firm)
                    .WithMany(p => p.PatientArbitrationAttorney)
                    .HasForeignKey(d => d.FirmId)
                    .HasConstraintName("FK_PatientArbitrationAttorney_LegalinfoFirmName");

                entity.HasOne(d => d.LeadingAttorney)
                    .WithMany(p => p.PatientArbitrationAttorney)
                    .HasForeignKey(d => d.LeadingAttorneyId)
                    .HasConstraintName("FK_PatientArbitrationAttorney_LegalInfoleadingAttorney");

                entity.HasOne(d => d.LeadingParalegal)
                    .WithMany(p => p.PatientArbitrationAttorney)
                    .HasForeignKey(d => d.LeadingParalegalId)
                    .HasConstraintName("FK_PatientArbitrationAttorney_LegalInfoLeadingParalegal");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PatientArbitrationAttorney)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientArbitrationAttorney_UserId");
            });

            modelBuilder.Entity<PatientCaseType>(entity =>
            {
                entity.HasKey(e => e.CaseTypeId);

                entity.Property(e => e.CaseTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PatientCaseType)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientCaseType_UserId");
            });

            modelBuilder.Entity<PatientClinicalNotes>(entity =>
            {
                entity.HasKey(e => e.ClinicalNoteId);

                entity.Property(e => e.NoteDate).HasColumnType("date");

                entity.Property(e => e.NoteNo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.NoteByNavigation)
                    .WithMany(p => p.PatientClinicalNotes)
                    .HasForeignKey(d => d.NoteBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientClinicalNotes_ProviderInfo");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientClinicalNotes)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_PatientClinicalNotes_PatientInfo");
            });

            modelBuilder.Entity<PatientDisplaySetting>(entity =>
            {
                entity.HasKey(e => e.DisplayId);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientDisplaySetting)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_PatientDisplaySetting_PatientInfo");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PatientDisplaySetting)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserID");
            });

            modelBuilder.Entity<PatientEmergencyContact>(entity =>
            {
                entity.HasKey(e => e.EmergencyContactID);

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Address2).HasMaxLength(250);

                entity.Property(e => e.Address3).HasMaxLength(250);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HomePhone).HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.MobilePhone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.Zip).HasMaxLength(30);

                entity.HasOne(d => d.Relationship)
                    .WithMany(p => p.PatientEmergencyContact)
                    .HasForeignKey(d => d.RelationshipId)
                    .HasConstraintName("FK_PatientEmergencyContact_PatientRelationship");

                //entity.HasOne(d => d.User)
                //    .WithMany(p => p.PatientEmergencyContact)
                //    .HasForeignKey(d => d.UserId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("fk_PatientEmergencyContact_UserId");
            });

            modelBuilder.Entity<PatientIdAndSignature>(entity =>
            {
                entity.HasKey(e => e.PatientSignatureId);

                entity.Property(e => e.ElectronicSignature)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IdNumber).HasMaxLength(20);

                entity.Property(e => e.PassportNumber).HasMaxLength(20);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.PatientIdAndSignature)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_PatientIdandSignature_PatientSignatureIdType");

                //entity.HasOne(d => d.User)
                //    .WithMany(p => p.PatientIdAndSignature)
                //    .HasForeignKey(d => d.UserId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("fk_PatientIdAndSignature_UserId");
            });

            modelBuilder.Entity<PatientInfo>(entity =>
            {
                entity.Property(e => e.AddressLine1).HasMaxLength(250);

                entity.Property(e => e.AddressLine2).HasMaxLength(250);

                entity.Property(e => e.AddressLine3).HasMaxLength(250);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PatientColor).HasMaxLength(20);

                entity.Property(e => e.PatientLanguage)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ReferralName).HasMaxLength(20);

                entity.Property(e => e.SSN).HasMaxLength(20);

                entity.Property(e => e.SecondaryAddress1).HasMaxLength(250);

                entity.Property(e => e.SecondaryAddress2).HasMaxLength(250);

                entity.Property(e => e.SecondaryAddress3).HasMaxLength(250);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(250);

                entity.Property(e => e.ZIP).HasMaxLength(30);

                entity.HasOne(d => d.EmploymentStatus)
                    .WithMany(p => p.PatientInfo)
                    .HasForeignKey(d => d.EmploymentStatusId)
                    .HasConstraintName("FK_PatientInfo_EmploymentStatus");

                entity.HasOne(d => d.EmploymentTitle)
                    .WithMany(p => p.PatientInfo)
                    .HasForeignKey(d => d.EmploymentTitleId)
                    .HasConstraintName("FK_PatientInfo_EmploymentTitle");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.PatientInfo)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("fk_PatientInfo_GenderId");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.PatientInfo)
                    .HasForeignKey(d => d.Language)
                    .HasConstraintName("FK_PatientInfo_PatientLanguage");

                entity.HasOne(d => d.PatientLegal)
                    .WithMany(p => p.PatientInfo)
                    .HasForeignKey(d => d.PatientLegalId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PatientInfo_PatientLegalStatus");

                entity.HasOne(d => d.PatientTreatment)
                    .WithMany(p => p.PatientInfo)
                    .HasForeignKey(d => d.PatientTreatmentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PatientInfo_PatientTreatmentStatus");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PatientInfo)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_PatientInfo_UserId");
            });

            modelBuilder.Entity<PatientLanguage>(entity =>
            {
                entity.HasKey(e => e.LanguageId);

                entity.Property(e => e.LanguageName).HasMaxLength(50);
            });

            modelBuilder.Entity<PatientLegalStatus>(entity =>
            {
                entity.HasKey(e => e.PatientLegalId);

                entity.Property(e => e.PatientLegalStatus1)
                    .IsRequired()
                    .HasColumnName("PatientLegalStatus")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PatientListDisplaySetting>(entity =>
            {
                entity.HasKey(e => e.PatientListDisplayId)
                    .HasName("PK__PatientL__88ED8A8815BEACC8");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.PatientListDisplaySetting)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK__PatientLi__Provi__0EE3280B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PatientListDisplaySetting)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__PatientLi__UserI__0FD74C44");
            });

            modelBuilder.Entity<PatientMedicalHistory>(entity =>
            {
                entity.HasKey(e => e.MedicalHistryId);

                entity.Property(e => e.CurrentStatus).HasMaxLength(50);

                entity.Property(e => e.DataYear).HasColumnType("smalldatetime");

                entity.Property(e => e.DocumentReport).HasMaxLength(50);

                entity.Property(e => e.MedicalHistoryTemplate).HasMaxLength(50);

                entity.HasOne(d => d.DiseaseType)
                    .WithMany(p => p.PatientMedicalHistory)
                    .HasForeignKey(d => d.DiseaseTypeId)
                    .HasConstraintName("FK_PatientMedicalHistory_MedicalDiseaseType");

                entity.HasOne(d => d.Examiner)
                    .WithMany(p => p.PatientMedicalHistory)
                    .HasForeignKey(d => d.ExaminerId)
                    .HasConstraintName("FK_PatientMedicalHistory_ProviderInfo");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientMedicalHistory)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_PatientMedicalHistory_PatientInfo");
            });

            modelBuilder.Entity<PatientMedicalProblem>(entity =>
            {
                entity.HasKey(e => e.MedicalProblemId);

                entity.Property(e => e.CurrentStatus).HasMaxLength(50);

                entity.Property(e => e.DateYear).HasColumnType("smalldatetime");

                entity.Property(e => e.DocumentReport).HasMaxLength(50);

                entity.HasOne(d => d.DiseaseType)
                    .WithMany(p => p.PatientMedicalProblem)
                    .HasForeignKey(d => d.DiseaseTypeId)
                    .HasConstraintName("FK_PatientMedicalProblem_MedicalDiseaseType");

                entity.HasOne(d => d.Examiner)
                    .WithMany(p => p.PatientMedicalProblem)
                    .HasForeignKey(d => d.ExaminerId)
                    .HasConstraintName("FK_PatientMedicalProblem_ProviderInfo");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientMedicalProblem)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_PatientMedicalProblem_PatientInfo");
            });

            modelBuilder.Entity<PatientMedicationsTemplate>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.FrequencyId).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Unit).HasMaxLength(20);

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.PatientMedicationsTemplate)
                    .HasForeignKey(d => d.MedicineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientMedicationsTemplate_Medicines");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.PatientMedicationsTemplate)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientMedicationsTemplate_PrescriptionTemplates");
            });

            modelBuilder.Entity<PatientNewCaseType>(entity =>
            {
                entity.HasKey(e => e.NewCaseTypeId);

                entity.Property(e => e.NewCaseTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PatientPersonalInjury>(entity =>
            {
                entity.HasKey(e => e.PersonalInjuryId);

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.AddressLine2).HasMaxLength(150);

                entity.Property(e => e.AddressLine3).HasMaxLength(150);

                entity.Property(e => e.AttorneyFields).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(20);

                entity.Property(e => e.LeadingAttorneyEmail).HasMaxLength(50);

                entity.Property(e => e.LeadingAttorneyExtension).HasMaxLength(50);

                entity.Property(e => e.LeadingAttorneyFax).HasMaxLength(20);

                entity.Property(e => e.LeadingAttorneyPhone).HasMaxLength(20);

                entity.Property(e => e.LeadingParalegalEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LeadingParalegalExtension).HasMaxLength(50);

                entity.Property(e => e.LeadingParalegalFax).HasMaxLength(50);

                entity.Property(e => e.LeadingParalegalPhone).HasMaxLength(50);

                entity.Property(e => e.LegalStatus).HasMaxLength(20);

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.Website).HasMaxLength(50);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Attorney)
                    .WithMany(p => p.PatientPersonalInjury)
                    .HasForeignKey(d => d.AttorneyID)
                    .HasConstraintName("FK_PatientPersonalInjury_LegalInfoAttorneyName");

                entity.HasOne(d => d.Firm)
                    .WithMany(p => p.PatientPersonalInjury)
                    .HasForeignKey(d => d.FirmId)
                    .HasConstraintName("FK_PatientPersonalInjury_LegalInfoFirmName");

                entity.HasOne(d => d.LeadingAttorney)
                    .WithMany(p => p.PatientPersonalInjury)
                    .HasForeignKey(d => d.LeadingAttorneyId)
                    .HasConstraintName("FK_PatientPersonalInjury_LegalInfoLeadingAttorney");

                entity.HasOne(d => d.LeadingParalegal)
                    .WithMany(p => p.PatientPersonalInjury)
                    .HasForeignKey(d => d.LeadingParalegalId)
                    .HasConstraintName("FK_PatientPersonalInjury_LegalInfoLeadingParalegal");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PatientPersonalInjury)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientPersonalInjury_Users");
            });

            modelBuilder.Entity<PatientPhoneNumber>(entity =>
            {
                entity.HasKey(e => e.PhoneNumberId);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EmergencyPhone).HasMaxLength(20);

                entity.Property(e => e.Fax).HasMaxLength(20);

                entity.Property(e => e.HomePhone).HasMaxLength(20);

                entity.Property(e => e.MobilePhone).HasMaxLength(20);

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.NewNumber).HasMaxLength(20);

                entity.Property(e => e.WorkPhone).HasMaxLength(20);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PatientPhoneNumber)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientPhoneNumber_UserId");
            });

            modelBuilder.Entity<PatientPrescriptions>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.FrequencyId).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Unit).HasMaxLength(20);

                entity.HasOne(d => d.Medication)
                    .WithMany(p => p.PatientPrescriptions)
                    .HasForeignKey(d => d.MedicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientPrescriptions_Medicines");

                entity.HasOne(d => d.PatientInfo)
                    .WithMany(p => p.PatientPrescriptions)
                    .HasForeignKey(d => d.PatientInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientPrescriptions_PatientInfo");
            });

            modelBuilder.Entity<PatientPrintSetting>(entity =>
            {
                entity.HasKey(e => e.PrintId);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientPrintSetting)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_PatientPrintSetting_PatientInfo");
            });

            modelBuilder.Entity<PatientRelationship>(entity =>
            {
                entity.HasKey(e => e.RelationshipId);

                entity.Property(e => e.RelationshipName).HasMaxLength(50);
            });

            modelBuilder.Entity<PatientRequireFieldsSetting>(entity =>
            {
                entity.HasKey(e => e.PatientRequiredFieldsId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PatientRequireFieldsSetting)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_PatientRequireFieldsSetting_Users");
            });

            modelBuilder.Entity<PatientRoleIncident>(entity =>
            {
                entity.HasKey(e => e.PatientIncidentRoleId);

                entity.Property(e => e.PatientRoleInIncident)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PatientSignatureIdType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.Property(e => e.TypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<PatientTreatmentStatus>(entity =>
            {
                entity.HasKey(e => e.PatientTreatmentId);

                entity.Property(e => e.PatientTreatmentStatus1)
                    .IsRequired()
                    .HasColumnName("PatientTreatmentStatus")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<PatientVitals>(entity =>
            {
                entity.HasKey(e => e.PatientVitalId)
                    .HasName("PK__PatientV__09888DB0795AC559");

                entity.Property(e => e.Allergies).HasMaxLength(100);

                entity.Property(e => e.BMI).HasMaxLength(100);

                entity.Property(e => e.BMIStatus).HasMaxLength(100);

                entity.Property(e => e.BloodPressure).HasMaxLength(100);

                entity.Property(e => e.ExamTime).HasColumnType("datetime");

                entity.Property(e => e.Height).HasMaxLength(100);

                entity.Property(e => e.OxygenSaturation).HasMaxLength(100);

                entity.Property(e => e.Pulse).HasMaxLength(100);

                entity.Property(e => e.Respiration).HasMaxLength(100);

                entity.Property(e => e.Results).HasMaxLength(200);

                entity.Property(e => e.TempMethod).HasMaxLength(100);

                entity.Property(e => e.Temprature).HasMaxLength(100);

                entity.Property(e => e.Weight).HasMaxLength(100);

                entity.HasOne(d => d.Examiner)
                    .WithMany(p => p.PatientVitals)
                    .HasForeignKey(d => d.ExaminerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PatientVi__Exami__1D66518C");

                //entity.HasOne(d => d.PatientInfo)
                //    .WithMany(p => p.PatientVitals)
                //    .HasForeignKey(d => d.PatientInfoId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__PatientVi__Patie__2BB470E3");

                entity.HasOne(d => d.ReasonForExam)
                    .WithMany(p => p.PatientVitals)
                    .HasForeignKey(d => d.ReasonForExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PatientVi__Reaso__27E3DFFF");
            });

            modelBuilder.Entity<PatientsClaimInfo>(entity =>
            {
                entity.HasKey(e => e.PatientClaimID);

                entity.Property(e => e.AcceptAssignment).HasMaxLength(20);

                entity.Property(e => e.Addressline1)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Addressline2).HasMaxLength(150);

                entity.Property(e => e.Addressline3).HasMaxLength(150);

                entity.Property(e => e.AdjusterEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AdjusterExtension).HasMaxLength(50);

                entity.Property(e => e.AdjusterFax).HasMaxLength(50);

                entity.Property(e => e.AdjusterID).HasMaxLength(10);

                entity.Property(e => e.AdjusterName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.AdjusterPhone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaseType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.ClaimNumber).HasMaxLength(50);

                entity.Property(e => e.CoPay).HasMaxLength(20);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DateOfIncident).HasColumnType("smalldatetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(20);

                entity.Property(e => e.GroupNumber).HasMaxLength(50);

                entity.Property(e => e.IncidentInCourse).HasMaxLength(20);

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.NF2FillingDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PlaceOfIncident).HasMaxLength(50);

                entity.Property(e => e.PolicyEffectAtIncidentTime).HasMaxLength(20);

                entity.Property(e => e.PolicyEffectEndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PolicyEffectiveDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PolicyHolderName).HasMaxLength(50);

                entity.Property(e => e.PolicyLimits).HasMaxLength(50);

                entity.Property(e => e.PolicyNumber).HasMaxLength(50);

                entity.Property(e => e.PrimaryInsuranceProvider)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PrimaryPhone).HasMaxLength(20);

                entity.Property(e => e.RelationShipToPolicyHolder).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.TimeOfIncident).HasColumnType("smalldatetime");

                entity.Property(e => e.WCBCaseNumber).HasMaxLength(50);

                entity.Property(e => e.WCBNumber).HasMaxLength(50);

                entity.Property(e => e.WasCasuseOfEmployment).HasMaxLength(50);

                entity.Property(e => e.WebPage).HasMaxLength(50);

                entity.Property(e => e.Zip).HasMaxLength(20);

                entity.HasOne(d => d.Attorney)
                    .WithMany(p => p.PatientsClaimInfo)
                    .HasForeignKey(d => d.AttorneyId)
                    .HasConstraintName("FK_PatientsClaimInfo_legalInfoAttorneyName");

                entity.HasOne(d => d.ClaimStatus)
                    .WithMany(p => p.PatientsClaimInfo)
                    .HasForeignKey(d => d.ClaimStatusId)
                    .HasConstraintName("FK_PatientsClaimInfo_ClaimStatus");

                entity.HasOne(d => d.IncidentReport)
                    .WithMany(p => p.PatientsClaimInfo)
                    .HasForeignKey(d => d.IncidentReportId)
                    .HasConstraintName("FK_PatientsClaimInfo_IncidentReportStatus");

                entity.HasOne(d => d.Nf2)
                    .WithMany(p => p.PatientsClaimInfo)
                    .HasForeignKey(d => d.Nf2Id)
                    .HasConstraintName("FK_PatientsClaimInfo_Nf2Status");

                entity.HasOne(d => d.PatientIncidentRole)
                    .WithMany(p => p.PatientsClaimInfo)
                    .HasForeignKey(d => d.PatientIncidentRoleId)
                    .HasConstraintName("FK_PatientsClaimInfo_PatientRoleIncident");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PatientsClaimInfo)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientsClaimInfo_Users");
            });

            modelBuilder.Entity<Pharmacy>(entity =>
            {
                entity.HasKey(e => e.P_ID);

                entity.Property(e => e.AddressLine1).HasMaxLength(50);

                entity.Property(e => e.AddressLine2).HasMaxLength(50);

                entity.Property(e => e.AddressLine3).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PharmacyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrescriptionTemplates>(entity =>
            {
                entity.HasKey(e => e.TemplateId);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.ProviderInfo)
                    .WithMany(p => p.PrescriptionTemplates)
                    .HasForeignKey(d => d.ProviderInfoId)
                    .HasConstraintName("FK_PrescriptionTemplates_ProviderInfo");
            });

            modelBuilder.Entity<ProviderInfo>(entity =>
            {
                entity.Property(e => e.AddressLine1).HasMaxLength(50);

                entity.Property(e => e.AddressLine2).HasMaxLength(250);

                entity.Property(e => e.AddressLine3).HasMaxLength(250);

                entity.Property(e => e.AllowSms).HasMaxLength(50);

                entity.Property(e => e.AssignRoomNo).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CodeByMasterProvider).HasMaxLength(50);

                entity.Property(e => e.ElectronicSignPassword).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EntityName).HasMaxLength(50);

                entity.Property(e => e.FaxNo).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.IsAllowToAddVisits).HasMaxLength(50);

                entity.Property(e => e.IsAllowToBill).HasMaxLength(50);

                entity.Property(e => e.IsAllowToSchedule).HasMaxLength(50);

                entity.Property(e => e.IsBilledAmountVisible).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.LicenseNo).HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.MobileNo).HasMaxLength(50);

                entity.Property(e => e.NpiNumber).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.ProviderPermission).HasMaxLength(250);

                entity.Property(e => e.ProviderProfilePic).HasMaxLength(500);

                entity.Property(e => e.Rent).HasMaxLength(50);

                entity.Property(e => e.SignImage).HasMaxLength(500);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.TaxId).HasMaxLength(50);

                entity.Property(e => e.Zip).HasMaxLength(50);

                entity.HasOne(d => d.RelatedFacility)
                    .WithMany(p => p.ProviderInfo)
                    .HasForeignKey(d => d.RelatedFacilityId)
                    .HasConstraintName("fk_ProviderInfo_RelatedFacilityId");

                entity.HasOne(d => d.RentTypeNavigation)
                    .WithMany(p => p.ProviderInfoRentTypeNavigation)
                    .HasForeignKey(d => d.RentType)
                    .HasConstraintName("fk_ProviderInfo_RentType");

                entity.HasOne(d => d.SpecialityNavigation)
                    .WithMany(p => p.ProviderInfo)
                    .HasForeignKey(d => d.Speciality)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_ProviderInfo_Speciality");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.ProviderInfoStatusNavigation)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("fk_ProviderInfo_Status");

                entity.HasOne(d => d.SuffixNavigation)
                    .WithMany(p => p.ProviderInfoSuffixNavigation)
                    .HasForeignKey(d => d.Suffix)
                    .HasConstraintName("fk_ProviderInfo_Suffix");

                entity.HasOne(d => d.TermNavigation)
                    .WithMany(p => p.ProviderInfo)
                    .HasForeignKey(d => d.Term)
                    .HasConstraintName("fk_ProviderInfo_Term");

                entity.HasOne(d => d.TitleNavigation)
                    .WithMany(p => p.ProviderInfoTitleNavigation)
                    .HasForeignKey(d => d.Title)
                    .HasConstraintName("fk_ProviderInfo_Title");

                entity.HasOne(d => d.UidTypeNavigation)
                    .WithMany(p => p.ProviderInfo)
                    .HasForeignKey(d => d.UidType)
                    .HasConstraintName("fk_ProviderInfo_UidType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProviderInfo)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_ProviderInfo_UserId");
            });

            modelBuilder.Entity<ProviderListSettingss>(entity =>
            {
                entity.HasKey(e => e.ProviderListId);

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.ProviderListSettingss)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK_ProviderListSettingss_ProviderInfo");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProviderListSettingss)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ProviderListSettingss_Users");
            });

            modelBuilder.Entity<ProviderSessionTypes>(entity =>
            {
                entity.HasKey(e => e.ProviderSessionTypeId)
                    .HasName("PK_ProviderSessionType");

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ProviderSessionType)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<ProviderSessions>(entity =>
            {
                entity.HasKey(e => e.ProviderSessionId)
                    .HasName("PK_ProviderSession");

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DateOfWeek).HasColumnType("datetime");

                entity.Property(e => e.DepartmentName).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");

                entity.HasOne(d => d.ProviderInfo)
                    .WithMany(p => p.ProviderSessions)
                    .HasForeignKey(d => d.ProviderInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProviderSessions_ProviderInfo");

                entity.HasOne(d => d.WeekDay)
                    .WithMany(p => p.ProviderSessions)
                    .HasForeignKey(d => d.WeekDayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProviderSession_WeekDays");
            });

            modelBuilder.Entity<ProviderSlots>(entity =>
            {
                entity.HasKey(e => e.SlotId);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DayOfWeek).HasColumnType("datetime");

                entity.Property(e => e.Duration).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.PatientInfo)
                    .WithMany(p => p.ProviderSlots)
                    .HasForeignKey(d => d.PatientInfoId)
                    .HasConstraintName("FK_ProviderSlots_PatientInfo");

                entity.HasOne(d => d.ProviderInfo)
                    .WithMany(p => p.ProviderSlots)
                    .HasForeignKey(d => d.ProviderInfoId)
                    .HasConstraintName("FK_ProviderSlots_ProviderInfo");

                entity.HasOne(d => d.ProviderSession)
                    .WithMany(p => p.ProviderSlots)
                    .HasForeignKey(d => d.ProviderSessionId)
                    .HasConstraintName("FK_ProviderSlots_ProviderSessions");
            });

            modelBuilder.Entity<ProviderSpecialities>(entity =>
            {
                entity.HasKey(e => e.ProviderSpecialityId);

                entity.Property(e => e.ProviderSpeciality).HasMaxLength(250);
            });

            modelBuilder.Entity<ProviderTemplates>(entity =>
            {
                entity.HasKey(e => e.ProviderTemplateId)
                    .HasName("PK_ProviderTemplates_1");

                entity.Property(e => e.ProviderTemplate)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProviderTerms>(entity =>
            {
                entity.HasKey(e => e.ProviderTermId);

                entity.Property(e => e.ProviderTerm).HasMaxLength(250);
            });

            modelBuilder.Entity<ProviderUIDTypes>(entity =>
            {
                entity.HasKey(e => e.ProviderUIDTypeId)
                    .HasName("PK_ProviderUIDType");

                entity.Property(e => e.ProviderUIDType).HasMaxLength(250);
            });

            modelBuilder.Entity<ProviderWorkingSchedule>(entity =>
            {
                entity.HasKey(e => e.ScheduleId);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Day)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<RelatedFacilities>(entity =>
            {
                entity.HasKey(e => e.RelatedFacilityId);

                entity.Property(e => e.RelatedFacility)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SecondaryInsurenceProvider>(entity =>
            {
                entity.HasKey(e => e.SecondaryInsuranceProviderID);

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.AddressLine2).HasMaxLength(150);

                entity.Property(e => e.AddressLine3).HasMaxLength(150);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.PlanName).HasMaxLength(50);

                entity.Property(e => e.PolicyNumber).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.SubscriberEmployer).HasMaxLength(50);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.website).HasMaxLength(50);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.SecondaryInsurenceProvider)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_SecondaryInsurenceProvider_InsuranceGroupNumber");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.SecondaryInsurenceProvider)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK_SecondaryInsurenceProvider_InsuranceProviderName");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SecondaryInsurenceProvider)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SecondaryInsurenceProvider_UserId");
            });

            modelBuilder.Entity<SoapNotesSurvey>(entity =>
            {
                entity.HasKey(e => e.SurveyNoteId);
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubContractorInfo>(entity =>
            {
                entity.HasKey(e => e.SubContractorId);

                entity.Property(e => e.AddressLine1).HasMaxLength(250);

                entity.Property(e => e.AddressLine2).HasMaxLength(250);

                entity.Property(e => e.AddressLine3).HasMaxLength(250);

                entity.Property(e => e.AssignRoomNo).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.ElectronicSignPassword).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EntityName).HasMaxLength(50);

                entity.Property(e => e.FaxNo).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.LicenseNo).HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.MobileNo).HasMaxLength(50);

                entity.Property(e => e.NpiNumber).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.Rent).HasMaxLength(50);

                entity.Property(e => e.SignImage).HasMaxLength(500);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.SubContractorProfilePic).HasMaxLength(500);

                entity.Property(e => e.TaxId).HasMaxLength(50);

                entity.Property(e => e.Zip).HasMaxLength(50);
            });

            modelBuilder.Entity<SubProviders>(entity =>
            {
                entity.HasKey(e => e.SubProviderId);

                entity.Property(e => e.SubProviderCode)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<SubscriptionPackages>(entity =>
            {
                entity.HasKey(e => e.PackageId);

                entity.Property(e => e.PackageDescriptin).HasMaxLength(128);

                entity.Property(e => e.PackageName).HasMaxLength(50);

                entity.Property(e => e.Plan_Id).HasMaxLength(100);

                entity.Property(e => e.ProductId).HasMaxLength(100);

                entity.Property(e => e.UserLimit).HasMaxLength(50);
            });

            modelBuilder.Entity<SurgeryCenter>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DOB).HasMaxLength(10);

                entity.Property(e => e.Email).HasMaxLength(20);

                entity.Property(e => e.FirstName).HasMaxLength(200);

                entity.Property(e => e.MRNumber).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TemplateComponent>(entity =>
            {
                entity.Property(e => e.ComponentId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ComponentLabel)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ComponentName).HasMaxLength(50);

                entity.Property(e => e.ComponentPlaceholder)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ComponentType)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.TemplateComponent)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TemplateComponent_Template");
            });

            modelBuilder.Entity<TemplateComponentDetail>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.TemplateComponent)
                    .WithMany(p => p.TemplateComponentDetail)
                    .HasForeignKey(d => d.TemplateComponentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TemplateComponentDetail_TemplateComponent");
            });

            modelBuilder.Entity<TertiaryInsurenceProvider>(entity =>
            {
                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.AddressLine2).HasMaxLength(150);

                entity.Property(e => e.AddressLine3).HasMaxLength(150);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.PlanName).HasMaxLength(50);

                entity.Property(e => e.PolicyNumber).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.SubscriberEmployer).HasMaxLength(50);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TertiaryInsurenceProvider)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_TertiaryInsurenceProvider_InsuranceGroupNumber");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.TertiaryInsurenceProvider)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK_TertiaryInsurenceProvider_InsuranceProviderName");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TertiaryInsurenceProvider)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TertiaryInsurenceProvider_UserId");
            });

            modelBuilder.Entity<Tests>(entity =>
            {
                entity.HasKey(e => e.TestId);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CPTCode)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.CPTCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tests_CPT");

                //entity.HasOne(d => d.DoctorInfo)
                //    .WithMany(p => p.Tests)
                //    .HasForeignKey(d => d.DoctorInfoId)
                //    .HasConstraintName("FK_Tests_DoctorInfo");

                entity.HasOne(d => d.ICDCode)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.ICDCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tests_ICD");
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.Property(e => e.PlanNo).HasMaxLength(50);

                entity.Property(e => e.TransactionNo).HasMaxLength(50);

                entity.Property(e => e.VerificationCode).HasMaxLength(10);
            });

            modelBuilder.Entity<UserInRoles>(entity =>
            {
                entity.HasKey(e => e.UserRoleId)
                    .HasName("PK_UserRoles");

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RoleType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserLanguage>(entity =>
            {
                entity.HasOne(d => d.Language)
                    .WithMany(p => p.UserLanguage)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_UserLanguage_PatientLanguage");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLanguage)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserLanguage_users");
            });

            modelBuilder.Entity<UserProfiles>(entity =>
            {
                entity.HasKey(e => e.UserProfileId)
                    .HasName("PK__UserProf__86F7F56DC280F6AF");

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PersonalAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ProfileImageURL)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserProfiles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_UserProfiles_UserId");
            });

            modelBuilder.Entity<UserRolePages>(entity =>
            {
                entity.HasKey(e => e.UserRolePageId);

                //entity.HasOne(d => d.MainMenu)
                //    .WithMany(p => p.UserRolePages)
                //    .HasForeignKey(d => d.MainMenuId)
                //    .HasConstraintName("FK_UserRolePages_MainMenuPages");

                //entity.HasOne(d => d.UserRole)
                //    .WithMany(p => p.UserRolePages)
                //    .HasForeignKey(d => d.UserRoleId)
                //    .HasConstraintName("FK_UserRolePages_UserInRoles");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.ConnectionId).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<VehicalsOrEntityInvolved>(entity =>
            {
                entity.HasKey(e => e.PatientVehicleID);

                entity.Property(e => e.Notes).HasMaxLength(250);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.Vehicle).HasMaxLength(50);

                entity.Property(e => e.VehicleInfo).HasMaxLength(50);

                entity.Property(e => e.VehicleLicense).HasMaxLength(30);

                entity.Property(e => e.VehicleResigrationState).HasMaxLength(50);

                entity.HasOne(d => d.InsuranceProvider)
                    .WithMany(p => p.VehicalsOrEntityInvolved)
                    .HasForeignKey(d => d.InsuranceProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicalsOrEntityInvolved_InsuranceProviderName");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VehicalsOrEntityInvolved)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicalsOrEntityInvolved_Users");
            });

            modelBuilder.Entity<VehicleInsuranceProvider>(entity =>
            {
                entity.Property(e => e.VehicleInsuranceProviderName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<WeekDays>(entity =>
            {
                entity.HasKey(e => e.WeekDayId);

                entity.Property(e => e.WeekDayId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.WeekDayName)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<vw_GetMHHospitalizationsInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_GetMHHospitalizationsInfo");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.CityName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.HospitalName).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.StateName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.illnessORinjury).HasMaxLength(20);
            });

            modelBuilder.Entity<vw_GetMHPharmacyInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_GetMHPharmacyInfo");

                entity.Property(e => e.Address).HasMaxLength(200);

                //entity.Property(e => e.CityName)
                //    .HasMaxLength(30)
                //    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.FaxNo).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                //entity.Property(e => e.StateName)
                //    .HasMaxLength(30)
                //    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
