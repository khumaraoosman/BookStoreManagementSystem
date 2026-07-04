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

        // Bütün müəllifləri kitabları ilə birlikdə gətirir
        public List<Author> GetAllWithBooks()
        {
            return _context.Authors
                .Include(x => x.Books)
                .ToList();
        }

        // Id-yə görə müəllifi kitabları ilə birlikdə gətirir
        public Author? GetByIdWithBooks(int id)
        {
            return _context.Authors
                .Include(x => x.Books)
                .FirstOrDefault(x => x.Id == id);
        }

        // Ada görə müəllif axtarışı
        public List<Author> SearchByName(string fullName)
        {
            return _context.Authors
                .Where(x => x.FullName.Contains(fullName))
                .ToList();
        }

        // Müəllifin kitablarını gətirir
        public List<Book> GetAuthorBooks(int authorId)
        {
            return _context.Books
                .Where(x => x.AuthorId == authorId)
                .ToList();
        }

        
    }
}
