using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.PatientInfoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class InvoicesViewModel
    {
        public PatientInfoBasicDto patient { get; set; }

        public InvoicesDto invoices { get; set; }

        public  List<InvoicesDto> invoicesList { get; set; }

        public List<InvoiceChargesDto> invoicesChargesList { get; set; }

    }
}
