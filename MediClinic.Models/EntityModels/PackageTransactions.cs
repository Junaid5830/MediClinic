using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PackageTransactions
    {
        public int PackageTransactionId { get; set; }
        public string TransactionId { get; set; }
        public long? EmployeeId { get; set; }
        public int? CodeForVerification { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
