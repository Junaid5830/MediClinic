using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs.MenuPagesDto

{
    public class MenuPagesBasicDto
    {
        public int MenuPageId { get; set; }
        public string Pagename { get; set; }
        public string PageActionName { get; set; }
        public string PageControllerName { get; set; }
        public bool PageIconType { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
