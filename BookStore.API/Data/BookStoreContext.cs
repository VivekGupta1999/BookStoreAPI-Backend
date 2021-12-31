using System;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data
{
	public class BookStoreContext: IdentityDbContext<User>
	{
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
			:base(options)
        {

        }

		public DbSet<Books> Books { get; set; }
        
        
    }
}

