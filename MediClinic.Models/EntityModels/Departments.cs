using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Departments
    {
        public int DepartmentsID { get; set; }
        public string DepName { get; set; }
        public int? Room { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
