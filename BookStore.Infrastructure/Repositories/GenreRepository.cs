using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Repositories
{
    
    

    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(BookStoreDbContext context)
            : base(context)
        {
        }

       
        public List<Genre> GetAllWithBooks()
        {
            return _context.Genres
                .Include(x => x.Books)
                .ToList();
        }

       
        public Genre? GetByIdWithBooks(int id)
        {
            return _context.Genres
                .Include(x => x.Books)
                .FirstOrDefault(x => x.Id == id);
        }

        
        public List<Genre> SearchByName(string name)
        {
            return _context.Genres
                .Where(x => x.Name.Contains(name))
                .ToList();
        }

       
        public List<Book> GetGenreBooks(int genreId)
        {
            return _context.Books
                .Where(x => x.GenreId == genreId)
                .ToList();
        }

        
    }
}
