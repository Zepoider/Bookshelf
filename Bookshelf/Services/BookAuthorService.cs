using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshelf.Services.Models;
using Bookshelf.Services.Interfaces;
using FluentValidation;
using Bookshelf.Models;

namespace Bookshelf.Services
{
    public class BookAuthorService : IBookAuthorService
    {
        public Task<IEnumerable<BookAuthorServ>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public BookAuthorServ GetCustomer(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveCustomer(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> SaveCustomerAsync(BookAuthorServ customer)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(BookAuthorServ customer)
        {
            throw new NotImplementedException();
        }
    }
}
