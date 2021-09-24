using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class UserRolePagesBasicDto
    {
        public int MainMenuId { get; set; }
        public string PageName { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public bool IsActive { get; set; }
        public int? UserRolePageId { get; set; }
        public int MainId { get; set; }

        public string MainIconPath { get; set; }

        public string SubMenuRole { get; set; }
        public int? ParentId { get; set; }
        public List<SubRolePage> SubRolePage { get; set; }
        public List<UserRolePagesBasicDto> SubMenu { get; set; }
        public virtual ICollection<SubMenuPages> SubMenuPages { get; set; }
        public virtual ICollection<UserRolePages> UserRolePages { get; set; }

    }
    public class PageList
    {
        public List<UserRolePagesBasicDto> UserRolePages { get; set; }
    }

    public class SubRolePage
    {
        public int MainMenuId { get; set; }
        public string PageName { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public bool IsActive { get; set; }
        public string PageIconPath { get; set; }
        
        public int ParentId { get; set; }
        public int? UserRolePageId { get; set; }
    }

    public class RolePageList
    {
        public List<SubRolePage> SubRolePage { get; set; }
    }
}
