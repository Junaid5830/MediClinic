using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class CptCodeGroupList
    {
        public int CptCodeGroupId { get; set; }
        public string CptCodeGroupName { get; set; }
        public int? TotalFee { get; set; }
        public string CptCodes { get; set; }
    }
}
