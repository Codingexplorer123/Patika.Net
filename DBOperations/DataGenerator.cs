using Microsoft.EntityFrameworkCore;


namespace WebApi.DBOperations
{
    public static class DataGenerator
    {
         public static void Initialize(BookStoreDbContext context)
         {
            
                if(context.Books.Any())
                {
                    return;
                }
                
                context.Books.AddRange(
                
                     new Book{
                
                Title = "Lean Startup",
                GenreId = 1, // Personal Growth
                PageCount = 200,
                PublishDate = new DateTime(2001,06,12)
                },
                     new Book{
                
                Title = "Herland",
                GenreId = 2, // Science Fiction
                PageCount = 250,
                PublishDate = new DateTime(2010,05,23)
                },
                     new Book{
             
                Title = "Dune",
                GenreId = 2, // Science Fiction
                PageCount = 540,
                PublishDate = new DateTime(2001,12,21)
                }); 

                context.SaveChanges();
        }
    }
    
}