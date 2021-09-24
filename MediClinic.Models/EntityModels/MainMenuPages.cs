using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class MainMenuPages
    {
        public MainMenuPages()
        {
            UserRolePages = new HashSet<UserRolePages>();
        }

        public int MainMenuId { get; set; }
        public string PageName { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public bool IsActive { get; set; }
        public string PageIconPath { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedId { get; set; }
        public int? CreatedId { get; set; }
        public int? ParentId { get; set; }

        public virtual ICollection<UserRolePages> UserRolePages { get; set; }
    }
}
