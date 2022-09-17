using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using TrialBookStore.Data;
using TrialBookStore.Data.Models;
using TrialBookStore.Model;

namespace TrialBookStore.BooksRepository
{
    public class BookRepository : IBookRepository
    {
        public BookStoreContext _context { get; }
        
        public BookRepository(BookStoreContext context)
        {
            _context = context;
            
        }

        public async Task<List<BooksModel>> GetAllBooksAsync()
        {
            var records = await _context.Books.Select(x => new BooksModel()
            {
                id = x.id,
                Title = x.Title,
                Author = x.Author,
                Description = x.Description
            }).ToListAsync();

            return records;
        }
        
        public async Task<BooksModel> GetBookByIdAsync(int id)
        {
            var records = await _context.Books.Where(x => x.id == id).Select(x => new BooksModel()
            {
                id = x.id,
                Title = x.Title,
                Author = x.Author,
                Description = x.Description
            }).FirstOrDefaultAsync();

            return records;
        }

        public async Task<int> AddBookAsync(BooksModel book)
        {
            var newBook = new Books(){
                Title = book.Title,
                Author = book.Author,
                Description = book.Description
            };

            _context.Add(newBook);
            await _context.SaveChangesAsync();
            return newBook.id;
        }

        public async Task UpdateBookAsync(int id, BooksModel updatedBook)
        {
            var book = new Books(){
                id = id,
                Title = updatedBook.Title,
                Author = updatedBook.Author,
                Description = updatedBook.Description
            };

            _context.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookPatchAsync(int id, JsonPatchDocument updatedBook)
        {
            var book = await _context.Books.FindAsync(id);
            if(book != null)
            {
                updatedBook.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}