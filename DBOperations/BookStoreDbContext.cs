using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class BookStoreDbContext: DbContext
    {
        public BookStoreDbContext (DbContextOptions<BookStoreDbContext> options) : base(options)
        {
            
        }
        public DbSet<Book> Books {get;set;}
        public DbSet<Genre> Genres {get; set;}
        public DbSet<Author> Authors {get; set;}

        protected void OodelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasOne<Author>().WithMany().HasForeignKey(k=>k.AuthorId).
                         OnDelete(DeleteBehavior.Restrict);
        }
    }

}