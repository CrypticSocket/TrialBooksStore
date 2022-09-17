using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrialBookStore.BooksRepository;
using TrialBookStore.Data;

namespace TrialBookStore.Services
{
    public static class ServiceBuilder
    {
        public static void BuildAllServices(WebApplicationBuilder builder)
        {
            var services = builder.Services;
            var connectionString = builder.Configuration.GetConnectionString("BooksStoreDb");

            services.AddControllers().AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(connectionString));

            // Dependency Injection
            services.AddTransient<IBookRepository, BookRepository>();
        }
    }
}