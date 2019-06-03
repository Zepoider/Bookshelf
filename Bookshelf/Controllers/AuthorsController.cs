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
    public class AuthorsController : ControllerBase
    {
        //private readonly ContextBookshelf _context;
        private readonly IMapper _mapper;
        private readonly IAuthorService _author;

        public AuthorsController(IMapper mapper, IAuthorService authors)
        {
            _author = authors ?? throw new ArgumentNullException(nameof(authors));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/Books
        [HttpGet]
        public async Task<IEnumerable<AuthorContr>> GetAllAuthorsAsync()
        {
            var map = _mapper.Map<IEnumerable<AuthorContr>>(await _author.GetAllAsync());

            return map.ToList();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooks([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var map = _mapper.Map<AuthorContr>(await _author.GetAsync(id) ?? null);

            if (map == null)
            {
                return NotFound();
            }

            return Ok(map);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooks([FromRoute] Guid id, [FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != author.AuthorId)
            {
                return BadRequest();
            }

            await _author.Update(_mapper.Map<AuthorServ>(author));

            return NoContent();
        }

        // POST: api/Books
        [HttpPost]
        public async Task<IActionResult> PostBooks([FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _author.SaveAsync(_mapper.Map<AuthorServ>(author));


            return CreatedAtAction("GetBooks", new { id = author.AuthorId }, author);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooks([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var map = _mapper.Map<AuthorServ>(await _author.GetAsync(id) ?? null);

            if (map == null)
            {
                return NotFound();
            }

            await _author.Remove(map);

            return Ok();
        }
    }
}