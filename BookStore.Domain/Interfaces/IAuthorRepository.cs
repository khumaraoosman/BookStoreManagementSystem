using BookStore.Domain.Entities;
using System.Collections.Generic;

namespace BookStore.Domain.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        List<Book> GetAuthorBooks(int authorId);
        List<Author> GetAllWithBooks();
        Author? GetByIdWithBooks(int id);
    }
}