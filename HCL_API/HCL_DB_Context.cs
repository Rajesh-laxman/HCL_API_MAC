using System;
using HCL_API.MODEL;
using Microsoft.EntityFrameworkCore;


/* 3.ADD DB_CONTEXT_CLASS */

namespace HCL_API.DB_CONTEXT
{
    public class HCL_DB_Context : DbContext
    {
        public HCL_DB_Context(DbContextOptions dBcontextoptions) : base(dBcontextoptions)
        {
        }

        public DbSet<EMPLOYEE> Emp_db_set { get; set; }
        public DbSet<Book> books_table { get; set; }
    }
}

/* 4.ADD CONNECTION_STRING */