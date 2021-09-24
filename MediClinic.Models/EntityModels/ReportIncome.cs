using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ReportIncome
    {
        public int IncomeId { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
        public int PatientId { get; set; }

        public virtual IncomeExpenceCategory Category { get; set; }
    }
}
