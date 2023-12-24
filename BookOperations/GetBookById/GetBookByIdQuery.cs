using System.Data.Common;
using AutoMapper;
using WebApi.BookOperations.GetBooks;
using WebApi.Common;
using WebApi.DBOperations;


namespace WebApi.BookOperations.GetBookById
{
    public class GetBookByIdQuery{

   
    private readonly BookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public int BookId {get;set;}
    public  GetBookByIdQuery(BookStoreDbContext dbContext,IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public BookDetailModel Handle()
    {
        var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
        if(book is null)
            throw new InvalidOperationException("Aradiginiz kitap listede yok");
        //BookDetailModel model = new BookDetailModel();
       BookDetailModel vm = _mapper.Map<BookDetailModel>(book);
       //  return new BookDetailModel
      // { 
       // Title = book.Title,
       // //Genre = ((GenreEnum)book.GenreId).ToString(),
       // Genre = Enum.GetName(typeof(GenreEnum), book.GenreId),
       // PageCount = book.PageCount,
      //  PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy")
      // }

        return vm;
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