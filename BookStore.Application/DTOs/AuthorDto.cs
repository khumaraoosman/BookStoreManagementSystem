using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }

        public List<string> BookNames { get; set; } = [];
    }

    public class CreateAuthorDto
    {
        public required string FullName { get; set; }
    }

    public class UpdateAuthorDto
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
    }
}
