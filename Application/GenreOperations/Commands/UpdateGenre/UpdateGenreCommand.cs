using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        public UpdateGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x=>x.Id == GenreId);
            if(genre is null)
                throw new InvalidOperationException ("Kitap Turu Bulunamadi");
            
            if(_context.Genres.Any(x=>x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
                throw new InvalidOperationException ("Ayni isimli bir kitap turu zaten mevcut");

            genre.Name = string.IsNullOrEmpty(Model.Name.Trim()) != default ? Model.Name : genre.Name;
            genre.isActive = Model.isActive;
            _context.SaveChanges();
        }
    }

    public class UpdateGenreModel{
        public string Name { get; set; }
        public bool isActive { get; set; } = true;
    }
}