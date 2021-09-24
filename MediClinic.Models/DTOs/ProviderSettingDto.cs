using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class ProviderSettingDto
    {

    }

    public class ProviderListSettingDto
    {
        public int ProviderListId { get; set; }
        public long? ProviderId { get; set; }
        public bool ProviderIdDisplay { get; set; }
        public bool EntityName { get; set; }
        public bool Name { get; set; }
        public bool Email { get; set; }
        public bool LicenseNo { get; set; }
        public bool NpiNumber { get; set; }
        public bool AssignRoomNo { get; set; }
        public bool PhoneNo { get; set; }
        public bool MobileNo { get; set; }
        public bool FaxNo { get; set; }
        public bool Address { get; set; }
        public bool TaxId { get; set; }

       
        public long? UserId { get; set; }
        public bool FirstName { get; set; }
        public bool LastName { get; set; }
    }
}
