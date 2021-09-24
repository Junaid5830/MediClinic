using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs.UserProfilesDto

{
    public class AuthUserProfileDto{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalAddress { get; set; }
        public string ProfileImageURL { get; set; }


    }
    public class UserProfilesBasicDto: AuthUserProfileDto
    {
        public long UserProfileId { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public int RoleTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedById { get; set; }
        public long? ModifiedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
