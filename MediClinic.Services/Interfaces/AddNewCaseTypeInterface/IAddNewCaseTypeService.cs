using MediClinic.Models.DTOs.AddNewCaseTypeDto;
using MediClinic.Models.DTOs.CommonDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.AddNewCaseTypeInterface
{
	public interface IAddNewCaseTypeService
	{
		public Task<ResponseDto<bool>> AddNewCaseType(AddNewCaseTypeBasicDto addNewCaseTypeBasicDto);
		public Task<ResponseDto<List<AddNewCaseTypeBasicDto>>> NewCaseList();

	}
}
