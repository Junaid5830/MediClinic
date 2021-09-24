using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class AdministrativeDto
    {
        public int AdministrativeID { get; set; }
        public string OfficerName { get; set; }
        public string BankLink { get; set; }
        public string OfficerTitle { get; set; }
        public string BankName { get; set; }
        public string CompanyName { get; set; }
        public string BankRoutingNumber { get; set; }
        public string TaxID { get; set; }
        public string BankAccountNumber { get; set; }
        public string LicenceNumber { get; set; }
        public string PaypalAccount { get; set; }
        public string NPINumber { get; set; }
        public string BillingAndSubscription { get; set; }
        public string CompanyAddress { get; set; }
        public string PaymentMethod { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyFax { get; set; }
        public string CompanyWebsite { get; set; }
        public string CompanyEmail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public string Photo { get; set; }
        public string Signature { get; set; }
        public bool IsActive { get; set; }

        public string HiddenPhoto { get; set; }
        public string HiddenSign { get; set; }
    }
}
