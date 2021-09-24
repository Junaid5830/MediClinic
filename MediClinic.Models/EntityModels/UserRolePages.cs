using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class UserRolePages
    {
        public int UserRolePageId { get; set; }
        public int? UserRoleId { get; set; }
        public int? MainMenuId { get; set; }

        public virtual MainMenuPages MainMenu { get; set; }
        public virtual UserInRoles UserRole { get; set; }
    }
}
