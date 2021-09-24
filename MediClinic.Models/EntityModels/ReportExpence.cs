using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ReportExpence
    {
        public int ExpenceId { get; set; }
        public int CategoryId { get; set; }
        public int PatientId { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }

        public virtual IncomeExpenceCategory Category { get; set; }
    }
}
