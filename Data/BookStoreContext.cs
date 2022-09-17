using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrialBookStore.Data.Models;

namespace TrialBookStore.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
            
        }

        public DbSet<Books> Books { get; set; }

        // You can define the connection string this way or through the start up class
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Server=.;Database=BooksStoreAPI;Integrated Security=True");
        //     base.OnConfiguring(optionsBuilder);
        // }
    }
}