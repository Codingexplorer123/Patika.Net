using System.ComponentModel.DataAnnotations;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBookById;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;


namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController: ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
           GetBooksQuery query = new GetBooksQuery(_context,_mapper);
           var result =query.Handle();
           return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            try
            {
                BookDetailModel result;
                GetBookByIdQuery query = new GetBookByIdQuery(_context,_mapper);
                query.BookId = id;
                GetBookByIdQueryValidator validator = new GetBookByIdQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handle();
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            
        }

        // [HttpGet]
        // public Book GetBy([FromQuery] string id)
        // {
        //     var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
        // }
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            try
            {
                command.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
               // FluentValidation.Results.ValidationResult result =validator.Validate(command);
          //      if(!result.IsValid)
                //    foreach(var item in result.Errors)
                   //     Console.WriteLine("Ozellik:" + item.PropertyName + "-Error Message:" + item.ErrorMessage);    
                
              //  else
               //     command.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            
            return Ok();
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookViewModel updatedBook)
        {
             UpdateBookCommand command = new UpdateBookCommand(_context,_mapper);
             command.BookId= id;
            try
            {
                command.Model = updatedBook;
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            
            return Ok();

        } 
        
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId= id;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}