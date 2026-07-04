using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        public List<int> OrderIds { get; set; } = [];
    }

    public class CreateCustomerDto
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
    }

    public class UpdateCustomerDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
    }

}
