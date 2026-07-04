using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DTOs
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<string> BookNames { get; set; } = [];
    }

    public class CreateGenreDto
    {
        public required string Name { get; set; }
    }

    public class UpdateGenreDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
