using Microsoft.EntityFrameworkCore;
using TrialBookStore.Data.Models;
using TrialBookStoreWebApi.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TrialBookStore.Data
{
    public class BookStoreContext : IdentityDbContext<UserModel>
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