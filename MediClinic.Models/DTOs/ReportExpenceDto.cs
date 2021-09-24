using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class ReportExpenceDto
    {
        public int ExpenceId { get; set; }
        public int CategoryId { get; set; }
        public int PatientId { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
    }
}
