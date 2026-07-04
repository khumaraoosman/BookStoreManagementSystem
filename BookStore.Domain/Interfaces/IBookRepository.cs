using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        List<Book> Search(string text);

        List<Book> GetBooksByAuthor(int authorId);

        List<Book> GetBooksByGenre(int genreId);

        List<Book> GetAllWithDetails();

        Book? GetByIdWithDetails(int id);

        List<Book> GetBooksByPrice(double minPrice, double maxPrice);
    }
}
