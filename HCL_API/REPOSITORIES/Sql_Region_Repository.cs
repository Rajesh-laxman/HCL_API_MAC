using System;
using HCL_API.DB_CONTEXT;
using HCL_API.MODEL;
using Microsoft.EntityFrameworkCore;

namespace HCL_API.REPOSITORIES
{
	public class Sql_Region_Repository: IRegionRepository
    {

		private readonly HCL_DB_Context hCL_DB_Context;
		public Sql_Region_Repository(HCL_DB_Context hCL_DB_Context)
		{
			this.hCL_DB_Context = hCL_DB_Context;
		}

		public async Task<List<EMPLOYEE>> Get_all_async()
		{
			var emp_domain = await hCL_DB_Context.Emp_db_set.ToListAsync();
			return emp_domain;
		}

		public async Task<EMPLOYEE> Get_emp_by_id_async(int ID)
		{
			var emp_detail = await hCL_DB_Context.Emp_db_set.FirstOrDefaultAsync(x=>x.E_ID ==ID);
			
			return emp_detail;
		}

		public async Task<EMPLOYEE> Add_an_emp_async(EMPLOYEE e)
		{
			await hCL_DB_Context.Emp_db_set.AddAsync(e);
			await hCL_DB_Context.SaveChangesAsync();
			return e;

		}

		public async Task<EMPLOYEE> Update_an_emp_async(EMPLOYEE e)
		{
			hCL_DB_Context.Emp_db_set.Update(e);
            await hCL_DB_Context.SaveChangesAsync();
            return e;
		}


		public async Task<EMPLOYEE> Delete_an_emp_async(EMPLOYEE e)
		{
			 hCL_DB_Context.Emp_db_set.Remove(e);
			await hCL_DB_Context.SaveChangesAsync();
			return e;
		}
    }
    
}

