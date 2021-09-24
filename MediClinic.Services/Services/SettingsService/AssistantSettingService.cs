using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.Assistant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediClinic.Services.Services.SettingsService
{
    class AssistantSettingService 
        //: IAssistantService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public AssistantSettingService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
