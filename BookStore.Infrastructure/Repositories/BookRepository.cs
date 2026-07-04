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

    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookStoreDbContext context)
            : base(context)
        {
        }

      
        public List<Book> GetAllWithDetails()
        {
            return _context.Books
                .Include(x => x.Author)
                .Include(x => x.Genre)
                .ToList();
        }

        
        public Book? GetByIdWithDetails(int id)
        {
            return _context.Books
                .Include(x => x.Author)
                .Include(x => x.Genre)
                .FirstOrDefault(x => x.Id == id);
        }

       
       

     
        public List<Book> GetBooksByAuthor(int authorId)
        {
            return _context.Books
                .Where(x => x.AuthorId == authorId)
                .ToList();
        }

   
        public List<Book> GetBooksByGenre(int genreId)
        {
            return _context.Books
                .Where(x => x.GenreId == genreId)
                .ToList();
        }

       
        public List<Book> GetBooksByPrice(double minPrice, double maxPrice)
        {
            return _context.Books
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
                .ToList();
        }

        public List<Book> Search(string text)
        {
            return _context.Books
                .Where(x => x.Name.Contains(text))
                .ToList();
        }

    }
}
