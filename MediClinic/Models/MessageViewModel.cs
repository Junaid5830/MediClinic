using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.PatientInfoListDto;
using MediClinic.Models.DTOs.ProviderInfoDto;
using MediClinic.Models.DTOs.UsersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class MessageViewModel
    {
        public MessagesDto message { get; set; }

        public List<MessagesDto> receiveMessages { get; set; }
        public List<MessagesDto> list { get; set; }
        public List<MessagesDto> Faciltylist { get; set; }
        public UsersBasicDto user { get; set; }
        public List<UsersBasicDto> userList { get; set; }
        public long userId{ get; set; }

        public List<InvoiceChargesDto> invoiceCharges { get; set; }
        public List<ProviderInfoBasicDto> ProviderList { get; set; }
        public List<PatientInfoListDto> patientListWithUsers { get; set; }

    }
}
