using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorByIdQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int AuthorId {get;set;}
    public  GetAuthorByIdQuery(BookStoreDbContext dbContext,IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public AuthorDetailModel Handle()
    {
        var yazar = _dbContext.Authors.Where(author => author.AuthorId== AuthorId).SingleOrDefault();
        if(yazar is null)
            throw new InvalidOperationException("Aradiginiz yazar listede yok");
        AuthorDetailModel vm = _mapper.Map<AuthorDetailModel>(yazar);
    
        return vm;
    }

    }
    public class AuthorDetailModel
    {
        public string Title { get; set; }   
        public int PageCount { get; set; }
        public String Genre { get; set; }
        public string PublishDate { get; set; }

    }
    
}