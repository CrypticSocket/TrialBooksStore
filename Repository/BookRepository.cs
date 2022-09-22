using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using TrialBookStore.Data;
using TrialBookStore.Data.Models;
using TrialBookStore.Modal;

namespace TrialBookStore.BooksRepository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        
        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<BooksModal>> GetAllBooksAsync()
        {
            var records = await _context.Books.ToListAsync();
            return _mapper.Map<List<BooksModal>>(records);
        }
        
        public async Task<BooksModal> GetBookByIdAsync(int id)
        {
            var records = await _context.Books.FindAsync(id);
            return _mapper.Map<BooksModal>(records);
        }

        public async Task<int> AddBookAsync(BooksModal book)
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

        public async Task UpdateBookAsync(int id, BooksModal updatedBook)
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

        public async Task DeleteBookById(int id)
        {
            var book = _context.Books.Find(id);
            _context.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}