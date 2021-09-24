using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedById { get; set; }
    }
}
