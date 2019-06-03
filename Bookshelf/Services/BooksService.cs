using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshelf.Services.Models;
using Bookshelf.Services.Interfaces;
using Bookshelf.Services.Validation;
using FluentValidation;
using Bookshelf.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;



namespace Bookshelf.Services
{
    public class BooksService : IBooksService
    {
        private readonly ContextBookshelf _context;
        private readonly IMapper _mapper;
        private readonly IValidator<BooksServ> _validator;
        public BooksService(ContextBookshelf context, IMapper mapper, IValidator<BooksServ> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<IEnumerable<BooksServ>> GetAllAsync()
        {
            var map = _mapper.Map<IEnumerable<BooksServ>>(await _context.DbBooks
            .AsNoTracking()
            .Where(a => a.SoftDeleted != true)
            .ToListAsync());

            return map;

        }

        public async Task<BooksServ> GetAsync(Guid id)
        {
            var map = _mapper.Map<BooksServ>(await _context.DbBooks
            .AsNoTracking()
            .Where(a => a.SoftDeleted != true)
            .FirstOrDefaultAsync(b => b.BooksId == id));

            return map;
        }

        public async Task Remove(BooksServ book)
        {

            book.SoftDeleted = true;

            _context.Entry(_mapper.Map<Books>(book)).State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }

        public async Task<Guid> SaveAsync(BooksServ book)
        {

            var validator = _validator.Validate(book);
            validator.ThrowIfInvalid();

            var books = await _context.DbBooks.AddAsync(_mapper.Map<Books>(book));
            await _context.SaveChangesAsync();

            return books.Entity.BooksId;
        }

        public async Task Update(BooksServ book)
        {
            var validator = _validator.Validate(book);
            validator.ThrowIfInvalid();

            _context.Entry(_mapper.Map<Books>(book)).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
