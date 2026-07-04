using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces
{
   
    
        public interface IGenreRepository : IRepository<Genre>
        {
            List<Genre> GetAllWithBooks();

            Genre? GetByIdWithBooks(int id);

            List<Genre> SearchByName(string name);

            List<Book> GetGenreBooks(int genreId);
        }
    
}
