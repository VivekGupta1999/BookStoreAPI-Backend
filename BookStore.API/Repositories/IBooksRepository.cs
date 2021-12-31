using System;
using BookStore.API.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace BookStore.API.Repositories
{
	public interface IBooksRepository
	{

		Task<List<Books>> GetAllBooksAsync();

		Task<Books> GetBookByIdAsync(int id);

		Task<Books> AddBookAsync(Books book);

		Task<Books> UpdateBookAsync(int id, Books book);


		Task<Books> UpdateBookSingleCallAsync(int id, Books book);

		Task<Books> UpdateBookPatchAsync(int id, JsonPatchDocument book);


		Task DeleteBookAsync(int id);

	}
}

