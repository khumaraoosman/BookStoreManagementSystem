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
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookStoreDbContext context)
            : base(context)
        {
        }

       
        public List<Author> GetAllWithBooks()
        {
            return _context.Authors
                .Include(x => x.Books)
                .ToList();
        }

       
        public Author? GetByIdWithBooks(int id)
        {
            return _context.Authors
                .Include(x => x.Books)
                .FirstOrDefault(x => x.Id == id);
        }

        
        public List<Author> SearchByName(string fullName)
        {
            return _context.Authors
                .Where(x => x.FullName.Contains(fullName))
                .ToList();
        }

      
        public List<Book> GetAuthorBooks(int authorId)
        {
            return _context.Books
                .Where(x => x.AuthorId == authorId)
                .ToList();
        }

        
    }
}
