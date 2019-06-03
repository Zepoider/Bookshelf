using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bookshelf.Models;
using AutoMapper;
using Bookshelf.Controllers.Models;
using Bookshelf.Services.Interfaces;
using Bookshelf.Services.Models;

namespace Bookshelf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBooksService _book;

        public BooksController(IMapper mapper, IBooksService books)
        {
            _book = books ?? throw new ArgumentNullException(nameof(books));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/Books
        [HttpGet]
        public async Task<IEnumerable<BooksContr>> GetAllBooksAsync(int page = 1, int objects = 10,
            bool sortDirection = true, string sortField = "Title")
        {
            var map = _mapper.Map<IEnumerable<BooksContr>>(await _book.GetAllAsync());

            if (sortDirection)
            {
                map = map.OrderBy(a => typeof(BooksContr).GetProperty(sortField).GetValue(a));
                SendMessage($"Sort ascend for {sortField} field");

            }
            else
            {
                map = map.OrderByDescending(a => typeof(BooksContr).GetProperty(sortField).GetValue(a));
            }

            var pagedMap = map.Skip((page - 1) * objects).Take(objects);

            return pagedMap;
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooks([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var map = _mapper.Map<BooksContr>(await _book.GetAsync(id) ?? null);

            if (map == null)
            {
                return NotFound();
            }

            return Ok(map);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooks([FromRoute] Guid id, [FromBody] Books book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.BooksId)
            {
                return BadRequest();
            }

            await _book.Update(_mapper.Map<BooksServ>(book));

            return NoContent();
        }

        // POST: api/Books
        [HttpPost]
        public async Task<IActionResult> PostBooks([FromBody] Books book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _book.SaveAsync(_mapper.Map<BooksServ>(book));


            return CreatedAtAction("GetBooks", new { id = book.BooksId }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooks([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var map = _mapper.Map<BooksServ>(await _book.GetAsync(id) ?? null);

            if (map == null)
            {
                return NotFound();
            }

            await _book.Remove(map);

            return Ok();
        }

        [HttpGet]
        IActionResult SendMessage(string message)
        {
            return Ok(message);
        }

    }
}