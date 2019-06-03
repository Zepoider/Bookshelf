using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshelf.Services.Models;

namespace Bookshelf.Services.Interfaces
{
    interface IReviewService
    {
        Task<IEnumerable<ReviewServ>> GetAllCustomersAsync();

        ReviewServ GetCustomer(Guid id);

        Task<Guid> SaveCustomerAsync(ReviewServ customer);

        bool UpdateCustomer(ReviewServ customer);

        bool RemoveCustomer(Guid id);
    }
}
