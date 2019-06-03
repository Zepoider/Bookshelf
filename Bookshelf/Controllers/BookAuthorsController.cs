using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bookshelf.Models;
using AutoMapper;
using Bookshelf.Controllers.Models;

namespace Bookshelf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorsController : ControllerBase
    {
        private readonly ContextBookshelf _context;

        public BookAuthorsController(ContextBookshelf context)
        {
            _context = context;
        }

        // GET: api/BookAuthors
        [HttpGet]
        public IEnumerable<BookAuthor> GetDbBookAuthor()
        {
            return _context.DbBookAuthor;
        }

        // GET: api/BookAuthors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookAuthor([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookAuthor = await _context.DbBookAuthor.FindAsync(id);

            if (bookAuthor == null)
            {
                return NotFound();
            }

            return Ok(bookAuthor);
        }

        // PUT: api/BookAuthors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookAuthor([FromRoute] Guid id, [FromBody] BookAuthor bookAuthor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookAuthor.BooksId)
            {
                return BadRequest();
            }

            _context.Entry(bookAuthor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookAuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookAuthors
        [HttpPost]
        public async Task<IActionResult> PostBookAuthor([FromBody] BookAuthor bookAuthor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DbBookAuthor.Add(bookAuthor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookAuthorExists(bookAuthor.BooksId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookAuthor", new { id = bookAuthor.BooksId }, bookAuthor);
        }

        // DELETE: api/BookAuthors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAuthor([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookAuthor = await _context.DbBookAuthor.FindAsync(id);
            if (bookAuthor == null)
            {
                return NotFound();
            }

            _context.DbBookAuthor.Remove(bookAuthor);
            await _context.SaveChangesAsync();

            return Ok(bookAuthor);
        }

        private bool BookAuthorExists(Guid id)
        {
            return _context.DbBookAuthor.Any(e => e.BooksId == id);
        }
    }
}