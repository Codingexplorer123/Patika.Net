using AutoMapper;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenresQuery;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBookById;
using WebApi.BookOperations.GetBooks;
using WebApi.Entities;
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
             opt=>opt.MapFrom(src=> src.Genre.Name));
             CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre,
             opt=>opt.MapFrom(src=> src.Genre.Name));

            CreateMap<UpdateBookViewModel,Book>();
            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre,GenreDetailViewModel>();
        }
    }
}