using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs.AssignMenuPageToUsersDTOs
{
    public class AssignMenuPageToUsersBasicDTO
    {
        public long AssignId { get; set; }
        public int RoleTypeId { get; set; }
        public int MenuPageId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
