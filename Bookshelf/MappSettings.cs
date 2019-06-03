using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bookshelf.Models;
using Bookshelf.Services.Models;
using Bookshelf.Controllers.Models;

namespace Bookshelf
{
    public class MappSettings : Profile
    {
        public MappSettings()
        {
            CreateMap<BooksContr, BooksServ>().ReverseMap();
            CreateMap<BooksServ, Books>().ReverseMap();

            CreateMap<AuthorContr, AuthorServ>().ReverseMap();
            CreateMap<AuthorServ, Author>().ReverseMap();
        }
    }
}
