using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class UserInRoles
    {
        public UserInRoles()
        {
            AssignMenuPageToUsers = new HashSet<AssignMenuPageToUsers>();
            Employee = new HashSet<Employee>();
            Notifications = new HashSet<Notifications>();
            UserRolePages = new HashSet<UserRolePages>();
        }

        public int UserRoleId { get; set; }
        public string RoleType { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedById { get; set; }
        public bool IsActive { get; set; }
        public bool? IsPermanent { get; set; }

        public virtual ICollection<AssignMenuPageToUsers> AssignMenuPageToUsers { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Notifications> Notifications { get; set; }
        public virtual ICollection<UserRolePages> UserRolePages { get; set; }
    }
}
