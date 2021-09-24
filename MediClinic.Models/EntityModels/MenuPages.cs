using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class MenuPages
    {
        public MenuPages()
        {
            AssignMenuPageToUsers = new HashSet<AssignMenuPageToUsers>();
        }

        public int MenuPageId { get; set; }
        public string PageName { get; set; }
        public string PageActionName { get; set; }
        public string PageControllerName { get; set; }
        public bool PageIconType { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<AssignMenuPageToUsers> AssignMenuPageToUsers { get; set; }
    }
}
