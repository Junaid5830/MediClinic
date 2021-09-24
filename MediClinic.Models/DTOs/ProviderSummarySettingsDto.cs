using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class ProviderSummarySettingsDto
    {
        public int ProviderPrintId { get; set; }
        public bool FirstName { get; set; }
        public bool LastName { get; set; }
        public bool ProviderIdPrint { get; set; }
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
        public long UserId { get; set; }
        public bool ProviderId { get; set; }
        public bool ScheduleListing { get; set; }
        public bool Speciality { get; set; }
        public bool Title { get; set; }
        public bool Suffix { get; set; }
        public bool DateCreated { get; set; }
    }
}
