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
    public class LineItemsController : ControllerBase
    {
        private readonly ContextBookshelf _context;

        public LineItemsController(ContextBookshelf context)
        {
            _context = context;
        }

        // GET: api/LineItems
        [HttpGet]
        public IEnumerable<LineItem> GetDbLineItems()
        {
            return _context.DbLineItems;
        }

        // GET: api/LineItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLineItem([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lineItem = await _context.DbLineItems.FindAsync(id);

            if (lineItem == null)
            {
                return NotFound();
            }

            return Ok(lineItem);
        }

        // PUT: api/LineItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLineItem([FromRoute] Guid id, [FromBody] LineItem lineItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lineItem.LineItemId)
            {
                return BadRequest();
            }

            _context.Entry(lineItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineItemExists(id))
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

        // POST: api/LineItems
        [HttpPost]
        public async Task<IActionResult> PostLineItem([FromBody] LineItem lineItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DbLineItems.Add(lineItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLineItem", new { id = lineItem.LineItemId }, lineItem);
        }

        // DELETE: api/LineItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLineItem([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lineItem = await _context.DbLineItems.FindAsync(id);
            if (lineItem == null)
            {
                return NotFound();
            }

            _context.DbLineItems.Remove(lineItem);
            await _context.SaveChangesAsync();

            return Ok(lineItem);
        }

        private bool LineItemExists(Guid id)
        {
            return _context.DbLineItems.Any(e => e.LineItemId == id);
        }
    }
}