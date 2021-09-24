using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class SubMenuPages
    {
        public SubMenuPages()
        {
            UserRolePages = new HashSet<UserRolePages>();
        }

        public int SubMenuId { get; set; }
        public string PageName { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public bool isActive { get; set; }
        public int? MainMenuId { get; set; }
        public string PageIconPath { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedId { get; set; }

        public virtual MainMenuPages MainMenu { get; set; }
        public virtual ICollection<UserRolePages> UserRolePages { get; set; }
    }
}
