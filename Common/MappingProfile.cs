using AutoMapper;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBookById;
using WebApi.BookOperations.GetBooks;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>(); // source,target(destination)
            CreateMap<Book,BookDetailModel>().ForMember(dest => dest.Genre,
             opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
             CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre,
             opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));

            CreateMap<UpdateBookViewModel,Book>();
        }
    }
}