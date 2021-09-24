using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class ReportIncomeDto
    {
        public int IncomeId { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
        public int PatientId { get; set; }
        public virtual IncomeExpenceCategory Category { get; set; }

    }
}
