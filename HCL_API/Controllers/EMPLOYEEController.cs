using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HCL_API.DB_CONTEXT;
using HCL_API.MODEL;
using HCL_API.MODEL.DTO;
using HCL_API.REPOSITORIES;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HCL_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EMPLOYEEController : ControllerBase
    {
        //private readonly HCL_DB_Context hCL_DB_Context;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        public EMPLOYEEController(IRegionRepository regionRepository,IMapper mapper)
        {
           // this.hCL_DB_Context = hCL_DB_Context;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("Print_all_employees")]
        /*https://localhost:7196/api/EMPLOYEE/Print_all_employees */
        public async Task<IActionResult> get_all_emp()
        {
            // var emp_DOMAIN_list =await hCL_DB_Context.Emp_db_set.ToListAsync();
            var emp_DOMAIN_list = await regionRepository.Get_all_async();

            List<EMP_DTO> eMP_DTO_list  = mapper.Map<List<EMP_DTO>>(emp_DOMAIN_list);

           // List<EMP_DTO> eMP_DTO_list = new List<EMP_DTO> { };
            //foreach(var x in emp_DOMAIN_list)
            //{
            //    eMP_DTO_list.Add(new EMP_DTO()
            //    {
            //        E_ID = x.E_ID,
            //        E_Name = x.E_Name,
            //        E_City = x.E_City,
            //        E_Design = x.E_Design
            //    });

            //}
            return Ok(eMP_DTO_list);
        }


        [HttpGet]
        [Route("Print_employee_by_ID")]
        /*https://localhost:7196/api/EMPLOYEE/Print_employee_by_ID?ID=2 */
        public async Task<IActionResult> get_emp_by_id (int ID)
        {
            //var emp_domain_detail = await hCL_DB_Context.Emp_db_set.FirstOrDefaultAsync(x => x.E_ID == ID);
            var emp_domain_detail =await  regionRepository.Get_emp_by_id_async(ID);
            if(emp_domain_detail == null)
            {
                return NotFound($"THIS ID [{ID}] IS NOT AVAILABLE IN DATA BASE.");
            }


            EMP_DTO eMP_DTO = mapper.Map<EMP_DTO>(emp_domain_detail);

            //EMP_DTO eMP_DTO = new EMP_DTO()
            //{
            //    E_ID = emp_domain_detail.E_ID,
            //    E_City = emp_domain_detail.E_City,
            //    E_Design = emp_domain_detail.E_Design,
            //    E_Name = emp_domain_detail.E_Name
            //};


            return Ok(eMP_DTO);
        }

        [HttpPost]
        [Route("Insert_an_employee")]
        /*https://localhost:7196/api/EMPLOYEE/Insert_an_employee */
        public async Task<IActionResult> create_an_emp([FromBody] EMP_DTO e)
        {
            //EMPLOYEE eMPLOYEE = new EMPLOYEE()
            //{
            //    E_Name = e.E_Name,
            //    E_Design = e.E_Design,
            //    E_City = e.E_City
            //};

            EMPLOYEE eMPLOYEE = mapper.Map<EMPLOYEE>(e);

            var emp = await regionRepository.Add_an_emp_async(eMPLOYEE);

            // await hCL_DB_Context.Emp_db_set.AddAsync(eMPLOYEE);
            //await hCL_DB_Context.SaveChangesAsync();
            EMP_DTO eMP_DTO = mapper.Map<EMP_DTO>(emp);
            return Ok(eMP_DTO);
        }

        [HttpPut]
        [Route("Update_an_employee")]
        /*https://localhost:7196/api/EMPLOYEE/Update_an_employee  */
        public async Task<IActionResult> update_an_emp([FromBody] EMP_DTO e)
        {
            //EMPLOYEE eMPLOYEE = new EMPLOYEE
            //{
            //    E_ID = e.E_ID,
            //    E_City = e.E_City,
            //    E_Design = e.E_Design,
            //    E_Name = e.E_Name
            //};

            EMPLOYEE eMPLOYEE = mapper.Map<EMPLOYEE>(e);
            var emp = await regionRepository.Update_an_emp_async(eMPLOYEE);
            // hCL_DB_Context.Emp_db_set.Update(eMPLOYEE);
            // await hCL_DB_Context.SaveChangesAsync();
            EMP_DTO eMP_DTO = mapper.Map<EMP_DTO>(emp);
            return Ok(eMP_DTO);
        }

        [HttpDelete]
        [Route("Delete_an_employee/{ID}")]
        /* https://localhost:7196/api/EMPLOYEE/Delete_an_employee/10 */
        public async Task<IActionResult> delete_an_emp([FromRoute] int ID)
        {
            //var emp_details = hCL_DB_Context.Emp_db_set.FirstOrDefault(x => x.E_ID == ID);
            var emp_details = await regionRepository.Get_emp_by_id_async(ID);
            if (emp_details == null)
            {
                return NotFound($"THIS ID [{ID}] IS NOT AVAILABLE IN DATA BASE.");
            }

            var emp = await regionRepository.Delete_an_emp_async(emp_details);
            // hCL_DB_Context.Emp_db_set.Remove(emp_details);
            //await hCL_DB_Context.SaveChangesAsync();


            //create automapper to convert domain model to dtos then pass this dtos

            EMP_DTO eMP_DTO = mapper.Map<EMP_DTO>(emp);
            return Ok(eMP_DTO);
        }


    }
    }

