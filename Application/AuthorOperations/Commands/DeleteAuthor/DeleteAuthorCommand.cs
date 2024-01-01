using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public DeleteAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x=>x.AuthorId == AuthorId);
            if(author is null)
                throw new InvalidOperationException("Silinecek Yazar bulunamadi");
            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
            
        }
    }
}