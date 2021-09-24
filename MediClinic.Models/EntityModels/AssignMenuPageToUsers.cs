using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class AssignMenuPageToUsers
    {
        public long AssignId { get; set; }
        public int RoleTypeId { get; set; }
        public int MenuPageId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual MenuPages MenuPage { get; set; }
        public virtual UserInRoles RoleType { get; set; }
    }
}
