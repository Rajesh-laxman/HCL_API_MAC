using System;
using HCL_API.MODEL;
using Microsoft.AspNetCore.Mvc;

namespace HCL_API.REPOSITORIES
{
	public interface IRegionRepository
	{


        Task<List<EMPLOYEE>> Get_all_async();
        Task<EMPLOYEE> Get_emp_by_id_async(int ID);
        Task<EMPLOYEE> Add_an_emp_async(EMPLOYEE e);
        Task<EMPLOYEE> Update_an_emp_async(EMPLOYEE e);
        Task<EMPLOYEE> Delete_an_emp_async(EMPLOYEE e);
    }

	
}

