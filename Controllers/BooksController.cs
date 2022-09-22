using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TrialBookStore.BooksRepository;
using TrialBookStore.Modal;

namespace TrialBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var books = await _bookRepository.GetBookByIdAsync(id);
            if(books == null) return NotFound();
            return Ok(books);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody]BooksModal book)
        {
            var id = await _bookRepository.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBookById), new{id = id, controller = "Books"}, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookById([FromRoute] int id, [FromBody] BooksModal updatedBook)
        {
            try
            {
                await _bookRepository.UpdateBookAsync(id, updatedBook);
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPatch([FromRoute] int id, [FromBody] JsonPatchDocument updatedBook)
        {
            try
            {
                await _bookRepository.UpdateBookPatchAsync(id, updatedBook);
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _bookRepository.DeleteBookById(id);
            return Ok(id);
        }
    }
}