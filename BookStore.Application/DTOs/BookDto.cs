using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? AuthorName { get; set; }
        public string? GenreName { get; set; }
    }

    public class CreateBookDto
    {
        public required string Name { get; set; }
        public double Price { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }

    public class UpdateBookDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Price { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }
}
