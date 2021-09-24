using MediClinic.Models.DTOs.UserInRolesDto;
using MediClinic.Models.DTOs.UsersDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.UsersDto
{

    public class AuthUserDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [RegularExpression(@"(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Enter minimum 8 character (at least one uppercase and one lowercase) and number or punctuation marks (such as ! and &).")]
        public string Password { get; set; }
        public int RoleTypeId { get; set; }


        public string UserName { get; set; }

        public List<UserInRolesBasicDto> UserRoleTypes{ get; set;}
        public UserInRolesBasicDto UserRoleTypesDto{ get; set;}

        public UserRolePagesBasicDto UserRolePagesBasicDto { get; set; }
        public List<UserRolePagesBasicDto> UserRolePagesList { get; set; }
        public EmployeeBasicDto employeeBasicDto { get; set; }
        public int currentTab { get; set; }
        public string SubscriptionId { get; set; }

        
        public string VerificationType { get; set; }
    }

    public class UsersBasicDto : AuthUserDto
    {
        public long UserId { get; set; }


        [Required(ErrorMessage = "User name is required.")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public DateTime? CreatedDate { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedById { get; set; }
        public bool IsActive { get; set; }
        public bool IsClient { get; set; }


    }
}
