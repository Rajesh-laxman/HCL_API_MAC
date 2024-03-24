using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HCL_API.DB_CONTEXT;
using HCL_API.MODEL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HCL_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EMPLOYEEController : ControllerBase
    {
        private readonly HCL_DB_Context hCL_DB_Context;
        public EMPLOYEEController(HCL_DB_Context hCL_DB_Context)
        {
            this.hCL_DB_Context = hCL_DB_Context;
        }

        [HttpGet]
        [Route("Print_all_employees")]
        /*https://localhost:7196/api/EMPLOYEE/Print_all_employees */
        public IActionResult get_all_emp()
        {
            var emp_list = hCL_DB_Context.Emp_db_set.ToList();
            return Ok(emp_list);
        }


        [HttpGet]
        [Route("Print_employee_by_ID")]
        /*https://localhost:7196/api/EMPLOYEE/Print_employee_by_ID?ID=2 */
        public IActionResult get_emp_by_id (int ID)
        {
            var emp_detail = hCL_DB_Context.Emp_db_set.FirstOrDefault(x => x.E_ID == ID);
            if(emp_detail == null)
            {
                return NotFound($"THIS ID [{ID}] IS NOT AVAILABLE IN DATA BASE.");
            }
            return Ok(emp_detail);
        }

        [HttpPost]
        [Route("Insert_an_employee")]
        /*https://localhost:7196/api/EMPLOYEE/Insert_an_employee */
        public IActionResult create_an_emp([FromBody] EMPLOYEE e)
        {
            hCL_DB_Context.Emp_db_set.Add(e);
            hCL_DB_Context.SaveChanges();
            return Ok(e);
        }

        [HttpPut]
        [Route("Update_an_employee")]
        /*https://localhost:7196/api/EMPLOYEE/Update_an_employee  */
        public IActionResult update_an_emp([FromBody] EMPLOYEE e)
        {
            hCL_DB_Context.Emp_db_set.Update(e);
            hCL_DB_Context.SaveChanges();
            return Ok(e);
        }

        [HttpDelete]
        [Route("Delete_an_employee/{ID}")]
        /* https://localhost:7196/api/EMPLOYEE/Delete_an_employee/10 */
        public IActionResult delete_an_emp([FromRoute] int ID)
        {
            var emp_details = hCL_DB_Context.Emp_db_set.FirstOrDefault(x => x.E_ID == ID);
            if (emp_details == null)
            {
                return NotFound($"THIS ID [{ID}] IS NOT AVAILABLE IN DATA BASE.");
            }
            hCL_DB_Context.Emp_db_set.Remove(emp_details);
            hCL_DB_Context.SaveChanges();
            return Ok(emp_details);
        }


    }





























        //    [HttpGet]  //https://localhost:7083/STUDENT/Display_Students
        //    [Route("Display_Students")]
        //    public IActionResult get_students()
        //    {
        //        //var student_details = ._STUDENTS.ToList();
        //        return Ok("summa summa");
        //    }

        //}
    }

