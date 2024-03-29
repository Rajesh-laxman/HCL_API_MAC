using System;
using HCL_API.DB_CONTEXT;
using HCL_API.MODEL;
using Microsoft.EntityFrameworkCore;

namespace HCL_API.REPOSITORIES
{
	public class Book_Repository: IBook_Interface
    {
        private readonly HCL_DB_Context hCL_DB_Context;


        public Book_Repository(HCL_DB_Context hCL_DB_Context)
		{
            this.hCL_DB_Context = hCL_DB_Context;
		}

        public async Task<List<Book>> get_all_async()
        {

            //var book_list =  await hCL_DB_Context.books_table.Where(x=>x.B_Name.Contains("46")).ToListAsync();
            var book_list =  await hCL_DB_Context.books_table.ToListAsync();
            return book_list;
        }

        public async Task<Book> get_book_by_id_async(int ID)
        {
            var book_details = await hCL_DB_Context.books_table.FirstOrDefaultAsync(x => x.B_ID == ID);
            
            return book_details;
        }

        public async Task<Book> create_book_async(Book book)
        {
            await hCL_DB_Context.books_table.AddAsync(book);
            await hCL_DB_Context.SaveChangesAsync();
            return book;
        }

        public async  Task<Book> update_book_async(Book book)
        {
             hCL_DB_Context.books_table.Update(book);
            await hCL_DB_Context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> delete_book_async(int id)
        {
            var book = hCL_DB_Context.books_table.Find(id);
            hCL_DB_Context.books_table.Remove(book);
            await hCL_DB_Context.SaveChangesAsync();
            return book;
        }
    }
}

