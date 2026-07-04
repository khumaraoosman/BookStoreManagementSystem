using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;

    }
}
