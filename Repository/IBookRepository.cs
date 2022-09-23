using Microsoft.AspNetCore.JsonPatch;
using TrialBookStore.Model;

namespace TrialBookStore.BooksRepository
{
    public interface IBookRepository
    {
        Task<List<BooksModel>> GetAllBooksAsync();
        Task<BooksModel> GetBookByIdAsync(int id);
        Task<int> AddBookAsync(BooksModel book);
        Task UpdateBookAsync(int id, BooksModel updatedBook);
        Task UpdateBookPatchAsync(int id, JsonPatchDocument updatedBook);
        Task DeleteBookById(int id);
    }
}