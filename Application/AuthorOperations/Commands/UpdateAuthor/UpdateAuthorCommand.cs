using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public UpdateAuthorViewModel Model {get; set;}
        public int AuthorId {get; set;}
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public UpdateAuthorCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x=>x.AuthorId == AuthorId);
            if(author is null)
                throw new InvalidOperationException("Bu isimde bir yazar yok");
            
            _mapper.Map(Model,author);
            _dbContext.Update(author);
            _dbContext.SaveChanges();

        }


        public class UpdateAuthorViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime? Birthday { get; set; }
        }
    }


    
}