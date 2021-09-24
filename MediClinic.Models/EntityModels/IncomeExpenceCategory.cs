using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class IncomeExpenceCategory
    {
        public IncomeExpenceCategory()
        {
            ReportExpence = new HashSet<ReportExpence>();
            ReportIncome = new HashSet<ReportIncome>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CategoryPrice { get; set; }

        public virtual ICollection<ReportExpence> ReportExpence { get; set; }
        public virtual ICollection<ReportIncome> ReportIncome { get; set; }
    }
}
