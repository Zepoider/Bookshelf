using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Bookshelf.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Bookshelf.Controllers.Models;
using Bookshelf.Services.Interfaces;
using Bookshelf.Services.Models;
using Bookshelf.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Bookshelf.Services.Validation;

namespace Bookshelf
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ContextBookshelf>(opts => opts.UseSqlServer(Configuration.GetConnectionString("Bookshelf")));

            services.AddMvc().AddFluentValidation();
            services.AddAutoMapper();
           
            services.AddScoped<IBooksService, BooksService>();
            services.AddTransient<IValidator<BooksServ>, BooksValidator>();

            services.AddScoped<IAuthorService, AuthorService>();
            services.AddTransient<IValidator<AuthorServ>, AuthorValidation>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
