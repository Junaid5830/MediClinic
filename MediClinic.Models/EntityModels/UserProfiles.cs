using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class UserProfiles
    {
        public long UserProfileId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PersonalAddress { get; set; }
        public string Phone { get; set; }
        public string ProfileImageURL { get; set; }
        public long UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedById { get; set; }
        public long? ModifiedById { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Users User { get; set; }
    }
}
