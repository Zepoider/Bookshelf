using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bookshelf.Services.Models;

namespace Bookshelf.Services.Interfaces
{
    public interface IBooksService
    {
        Task<IEnumerable<BooksServ>> GetAllAsync();

        Task<BooksServ> GetAsync(Guid id);

        Task<Guid> SaveAsync(BooksServ book);

        Task Update(BooksServ book);

        Task Remove(BooksServ book);
    }
}
