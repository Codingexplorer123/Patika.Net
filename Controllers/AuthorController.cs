using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.Commands.CreateAuthor;
using WebApi.Application.Commands.DeleteAuthor;
using WebApi.Application.Commands.UpdateAuthor;
using WebApi.BookOperations.GetBookById;
using WebApi.DBOperations;
using static WebApi.Application.Commands.CreateAuthor.CreateAuthorCommand;
using static WebApi.Application.Commands.UpdateAuthor.UpdateAuthorCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController: ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
           GetAuthorsQuery query = new GetAuthorsQuery(_context,_mapper);
           var result =query.Handle();
           return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {         
            AuthorDetailModel result;
            GetAuthorByIdQuery command = new GetAuthorByIdQuery(_context,_mapper);
            command.AuthorId = id;
            GetAuthorByIdQueryValidator validator = new GetAuthorByIdQueryValidator();
            validator.ValidateAndThrow(command);
            result = command.Handle();
            
            return Ok(result);
              
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
            
            command.Model = newAuthor;
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
          
            return Ok();
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateAuthorViewModel updatedBook)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context,_mapper);
            command.AuthorId= id;
            
            command.Model = updatedBook;
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();

        } 
        
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId= id;
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();
        }
    }
}
