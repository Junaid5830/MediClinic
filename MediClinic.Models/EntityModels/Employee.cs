using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Employee
    {
        public Employee()
        {
            AmbulanceAssignDriver = new HashSet<AmbulanceAssignDriver>();
            PackageTransactions = new HashSet<PackageTransactions>();
        }

        public long Employee_id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public int? GenderId { get; set; }
        public int? MaritalStatusId { get; set; }
        public int? RaceEthnicityId { get; set; }
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public string Addressline3 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long? UserId { get; set; }
        public bool? isActive { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string EmployeeImage { get; set; }
        public string WriteSignature { get; set; }
        public string UploadSignatureImage { get; set; }
        public int? createdById { get; set; }
        public int? EmploymentRoleId { get; set; }
        public bool isUser { get; set; }
        public string MobNo { get; set; }
        public bool? isdeleted { get; set; }
        public string LicenseNo { get; set; }

        public virtual UserInRoles EmploymentRole { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<AmbulanceAssignDriver> AmbulanceAssignDriver { get; set; }
        public virtual ICollection<PackageTransactions> PackageTransactions { get; set; }
    }
}
