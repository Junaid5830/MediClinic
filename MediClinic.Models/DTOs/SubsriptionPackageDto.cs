using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
   public  class SubsriptionPackageDto
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public int? PackagePrice { get; set; }
        public int? ProviderNo { get; set; }
        public string UserLimit { get; set; }
        public int? DataStorage { get; set; }
        public decimal? AdditionalGB { get; set; }
        public decimal? AdditionalTB { get; set; }
        public string ProductId { get; set; }
        public string PackageDescriptin { get; set; }
        public bool? Negitable { get; set; }
        public bool? isActive { get; set; }
        public string Plan_Id { get; set; }
    }


}
