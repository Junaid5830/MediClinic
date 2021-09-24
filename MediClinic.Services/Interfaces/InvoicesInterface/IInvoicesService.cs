using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.PatientInfoDto;
using MediClinic.Models.DTOs.UsersDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.InvoicesInterface
{
    public interface IInvoicesService
    {
        public PatientInfoBasicDto GetPaitent(int id);

        public int Add(InvoicesDto invDto);

        public  Task<List<InvoicesDto>> GetInvoicesList();
        public  Task<List<InvoicesDto>> GetInvoicesListOfVisits(long Id);
        public  Task<List<InvoicesDto>> GetInvoicesVisitList(int Id);

        public bool Delete(int invoiceId);
        public InvoicesDto GetInvoiceById(int invId);
        public bool AddCharges(List<InvoiceChargesDto> charges);

        public Task<List<InvoiceChargesDto>> GetInvoicesChargesList(int invChargId);

        public bool ChargesDelete(int invoiceCId);



    }
}
