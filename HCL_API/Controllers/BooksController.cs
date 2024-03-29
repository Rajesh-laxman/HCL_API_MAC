using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HCL_API.MODEL;
using HCL_API.REPOSITORIES;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HCL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBook_Interface book_Interface;
        public BooksController(IBook_Interface book_Interface)
        {
            this.book_Interface = book_Interface;
        }

        [HttpGet]
        public async Task<IActionResult> get_all_books()
        {
            var book_list = await book_Interface.get_all_async();
            return Ok(book_list);
        }

        [HttpPost]
        public async Task<IActionResult> create_book_details([FromBody] Book b)
        {
            var book_details = await book_Interface.create_book_async(b);
            return Ok(book_details);
        }

        [HttpGet("{ID}")]
        public async Task<IActionResult> get_book_by_id([FromRoute] int ID)
        {
            var book = await book_Interface.get_book_by_id_async(ID);
            if (book == null)
            {
                return NotFound("INPUT ID IS NOT AVAILABLE IN DB");
            }
            return Ok(book);
        }

        [HttpPut]
        public async Task<IActionResult> update_from_body([FromBody] Book book)
        {
            var updated_book = await book_Interface.update_book_async(book);
            return Ok(updated_book);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> delete_from_boy([FromRoute] int id)
        {
            var deleted_book = await book_Interface.delete_book_async(id);
            return Ok(deleted_book);
        }





        //// GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

