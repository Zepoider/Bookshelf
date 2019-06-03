using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bookshelf.Services.Models;

namespace Bookshelf.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorServ>> GetAllAsync();

        Task<AuthorServ> GetAsync(Guid id);

        Task<Guid> SaveAsync(AuthorServ author);

        Task Update(AuthorServ author);

        Task Remove(AuthorServ author);
    }
}
