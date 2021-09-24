using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Radiology
    {
        public int Id { get; set; }
        public string RadiologyName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
