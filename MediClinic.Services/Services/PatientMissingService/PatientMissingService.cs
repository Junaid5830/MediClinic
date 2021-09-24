using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs.NotificationDto;
using MediClinic.Models.DTOs.PatientMissingDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientMissingInterface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientMissingService
{
    public class PatientMissingService : IPatientMissingService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public PatientMissingService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PatientMissingsDto>> GetPatientInfoMissingFieldsByPatientId(long patientId)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var actualList = new List<PatientMissingsDto>();
                var result = await  conn.QueryAsync<PatientMissingsDto>(sql: "[GetPatientInfoFormMissingFieldsTest]", param: new { patientInfoId = patientId },
                commandType: CommandType.StoredProcedure);
                var missingList = result.ToList();

                if (!(missingList is null) && missingList.Count > 0)
                {
                    foreach (var item in missingList)
                    {
                        if (!string.IsNullOrEmpty(item.MissingFields))
                        {
                            item.MissingFieldsList = item.MissingFields.Split(',').ToList();
                            actualList.Add(item);
                        }
                    }
                }
                else
                {
                    actualList = new List<PatientMissingsDto>();
                }

                return actualList;
            }
        }

        public async Task<NotificationDto> GetPatientInfoMissingFieldsByPatientIdForNotification(long patientId)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var actualList = new List<PatientMissingsDto>();
                var notifyDtoObj = new NotificationDto();

                var result = await conn.QueryAsync<PatientMissingsDto>(sql: "[GetPatientInfoFormMissingFieldsTest]", param: new { patientInfoId = patientId },
                commandType: CommandType.StoredProcedure);
                var missingList = result.ToList();

                if (!(missingList is null) && missingList.Count > 0)
                {
                    foreach (var item in missingList)
                    {
                        if (!string.IsNullOrEmpty(item.MissingFields))
                        {
                            item.MissingFieldsList = item.MissingFields.Split(',').ToList();
                            actualList.Add(item);
                        }
                    }

                    notifyDtoObj.PatientMissingsListDtos = actualList;
                }
                else
                {
                    notifyDtoObj = new NotificationDto();
                }

                return notifyDtoObj;
            }
        }

    }
}
