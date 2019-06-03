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
    public class AuthorService : IAuthorService
    {
        private readonly ContextBookshelf _context;
        private readonly IMapper _mapper;
        private readonly IValidator<AuthorServ> _validator;
        public AuthorService(ContextBookshelf context, IMapper mapper, IValidator<AuthorServ> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<IEnumerable<AuthorServ>> GetAllAsync()
        {
            var map = _mapper.Map<IEnumerable<AuthorServ>>(await _context.DbAuthors
            .AsNoTracking()
            .ToListAsync());

            return map.ToList();

        }

        public async Task<AuthorServ> GetAsync(Guid id)
        {
            var map = _mapper.Map<AuthorServ>(await _context.DbAuthors
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.AuthorId == id));

            return map;
        }

        public async Task Remove(AuthorServ author)
        {


            _context.DbAuthors.Remove(_mapper.Map<Author>(author));

            await _context.SaveChangesAsync();

        }

        public async Task<Guid> SaveAsync(AuthorServ author)
        {

            var validator = _validator.Validate(author);
            validator.ThrowIfInvalid();

            var books = await _context.DbAuthors.AddAsync(_mapper.Map<Author>(author));
            await _context.SaveChangesAsync();

            return books.Entity.AuthorId;
        }

        public async Task Update(AuthorServ author)
        {
            var validator = _validator.Validate(author);
            validator.ThrowIfInvalid();

            _context.Entry(_mapper.Map<Author>(author)).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
