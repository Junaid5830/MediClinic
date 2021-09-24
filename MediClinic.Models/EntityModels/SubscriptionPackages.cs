using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class SubscriptionPackages
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public int? PackagePrice { get; set; }
        public int? ProviderNo { get; set; }
        public string UserLimit { get; set; }
        public int? DataStorage { get; set; }
        public int? AdditionalGB { get; set; }
        public int? AdditionalTB { get; set; }
        public string ProductId { get; set; }
        public string PackageDescriptin { get; set; }
        public bool? Negitable { get; set; }
        public bool isActive { get; set; }
        public string Plan_Id { get; set; }
    }
}
