using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        List<Book> GetAuthorBooks(int authorId);
    }
}
