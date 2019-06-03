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
    public class ReviewService : IReviewService
    {


        public Task<IEnumerable<ReviewServ>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public ReviewServ GetCustomer(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveCustomer(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> SaveCustomerAsync(ReviewServ customer)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(ReviewServ customer)
        {
            throw new NotImplementedException();
        }
    }
}
