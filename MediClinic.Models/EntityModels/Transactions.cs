using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Transactions
    {
        public int TransactionId { get; set; }
        public long? EmployeeId { get; set; }
        public string PlanNo { get; set; }
        public string TransactionNo { get; set; }
        public string VerificationCode { get; set; }
    }
}
