using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
