using System;
using AutoMapper;
using HCL_API.MODEL;
using HCL_API.MODEL.DTO;

namespace HCL_API.MAPPINGS
{
	public class AUTO_MAPPER:Profile
	{ 
		public AUTO_MAPPER()
		{
			CreateMap<EMPLOYEE, EMP_DTO>();
			CreateMap<EMPLOYEE, EMP_DTO>().ReverseMap();
		}
	}
}

