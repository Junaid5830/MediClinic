using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class spGetDoctorTemplateDTO
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int TemplateId { get; set; }
        public string Name { get; set; }
    }
}
