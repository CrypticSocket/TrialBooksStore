using Microsoft.AspNetCore.JsonPatch;
using TrialBookStore.Modal;

namespace TrialBookStore.BooksRepository
{
    public interface IBookRepository
    {
        Task<List<BooksModal>> GetAllBooksAsync();
        Task<BooksModal> GetBookByIdAsync(int id);
        Task<int> AddBookAsync(BooksModal book);
        Task UpdateBookAsync(int id, BooksModal updatedBook);
        Task UpdateBookPatchAsync(int id, JsonPatchDocument updatedBook);
        Task DeleteBookById(int id);
    }
}