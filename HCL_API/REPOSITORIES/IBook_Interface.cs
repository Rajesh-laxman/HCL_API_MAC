using System;
using HCL_API.MODEL;

namespace HCL_API.REPOSITORIES
{
	public interface IBook_Interface
	{
		Task<List<Book>> get_all_async();
        Task<Book> create_book_async(Book book);
		Task<Book> get_book_by_id_async(int ID);
		Task<Book> update_book_async(Book book);
		Task<Book> delete_book_async(int id);
	}
}

