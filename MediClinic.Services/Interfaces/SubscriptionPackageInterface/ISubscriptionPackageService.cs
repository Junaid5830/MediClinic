using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.SubscriptionPackageInterface
{
    public interface ISubscriptionPackageService
    {
        public Task<ResponseDto<bool>> CreateSubScription(SubsriptionPackageDto subscriptionPackageDto);

        public Task<ResponseDto<List<SubsriptionPackageDto>>> SubscriptionPackageList();

        public Task<ResponseDto<bool>> CreateTransaction(string TransactionId,long EmployeeId);

        public bool UpdateTransactionForVerifcationCode(long EmpId, int Code);

        public PackageTransactions GetRecByEmpId(long EmpId);
       
    }
}
