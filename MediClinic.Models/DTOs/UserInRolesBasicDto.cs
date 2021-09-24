using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.UserInRolesDto

{
    public class UserInRolesBasicDto
    {
        public int UserRoleId { get; set; }
        [Required]
        public string RoleType { get; set; }

        public bool IsActive { get; set; }
        public bool? IsPermanent { get; set; }

    }
}
