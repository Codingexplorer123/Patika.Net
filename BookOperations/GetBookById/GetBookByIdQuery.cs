using System.Data.Common;
using WebApi.BookOperations.GetBooks;
using WebApi.Common;
using WebApi.DBOperations;


namespace WebApi.BookOperations.GetBookById
{
    public class GetBookByIdQuery{

   
    private readonly BookStoreDbContext _dbContext;
    public int BookId {get;set;}
    public  GetBookByIdQuery(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public BookDetailModel Handle()
    {
        var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
        if(book is null)
            throw new InvalidOperationException("Aradiginiz kitap listede yok");
        //BookDetailModel model = new BookDetailModel();
       return new BookDetailModel
       {
        Title = book.Title,
        Genre = Enum.GetName(typeof(GenreEnum), book.GenreId),
        PageCount = book.PageCount,
        PublishDate = book.PublishDate.ToString("dd/MM/yyyy")
       };

    }

    }
    public class BookDetailModel
    {
        public string Title { get; set; }   
        public int PageCount { get; set; }
        public String Genre { get; set; }
        public string PublishDate { get; set; }

    }
    
}