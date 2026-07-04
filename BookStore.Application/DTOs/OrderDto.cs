using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

        public string? CustomerName { get; set; }

        public List<string> BookNames { get; set; } = [];
    }

    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
    }

    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
    }
}
