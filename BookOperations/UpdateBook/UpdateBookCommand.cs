using System.Data.Common;
using AutoMapper;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.UpdateBook
{

    public class UpdateBookCommand
    {
        public UpdateBookViewModel Model { get; set; }
        public int BookId {get; set;}
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public UpdateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    


    public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=>x.Id == BookId );
            if(book is null)
                throw new InvalidOperationException("Bu isimde bir kitap yok");
            
            _mapper.Map(Model,book);

            // book.PageCount = Model.PageCount !=default ? Model.PageCount : book.PageCount;
            // book.PublishDate = Model.PublishDate !=default ? Model.PublishDate : book.PublishDate;
            // book.GenreId = Model.GenreId !=default ? Model.GenreId : book.GenreId;
            // book.Title = Model.Title !=default ? Model.Title : book.Title;
             
            _dbContext.Update(book);
            _dbContext.SaveChanges();
            
        }

        public class UpdateBookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public int GenreId { get; set; }
    }
    }
}