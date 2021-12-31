using System;
using BookStore.API.Data;
using BookStore.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
	public class BooksRepository: IBooksRepository
	{
        private readonly BookStoreContext _context;
          
        public BooksRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<Books> UpdateBookAsync(int id, Books book)
        {
          
            var oldBook = await _context.Books.FindAsync(id);
            if (oldBook != null)
            {
                oldBook.Title = book.Title;
                oldBook.Description = book.Description;
                await _context.SaveChangesAsync();
            }
            return oldBook;
        }

        public async Task<Books> AddBookAsync(Books book)
        {
             _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<List<Books>> GetAllBooksAsync()
        {
            var records = await _context.Books.ToListAsync();

            return records;
        }

        public async Task<Books> GetBookByIdAsync(int id)
        {
            var book = await _context.Books.Where(x => x.Id == id).FirstOrDefaultAsync();

            return book;
        }

        public async Task<Books> UpdateBookSingleCallAsync(int id, Books book)
        {
            Books Book = new()
            {
                Id = id,
                Title = book.Title,
                Description = book.Description

            };
            _context.Books.Update(Book);
            await _context.SaveChangesAsync();
            return Book;
        }

        public async Task<Books> UpdateBookPatchAsync(int id, JsonPatchDocument book)
        {
            var Book = await _context.Books.FindAsync(id);
            if(Book != null)
            {
                book.ApplyTo(Book);
                await _context.SaveChangesAsync();
            }
            return Book;
            
        }

        public async Task DeleteBookAsync(int id)
        {
            Books book = new()
            {
                Id = id
            };
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}

