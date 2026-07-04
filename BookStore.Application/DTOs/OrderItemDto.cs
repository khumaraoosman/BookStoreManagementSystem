using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DTOs
{
    public class OrderItemDto
    {
        public int Id { get; set; }

        public string? BookName { get; set; }

        public int Quantity { get; set; }
    }

    public class CreateOrderItemDto
    {
        public int OrderId { get; set; }

        public int BookId { get; set; }

        public int Quantity { get; set; }
    }

    public class UpdateOrderItemDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int BookId { get; set; }

        public int Quantity { get; set; }
    }
}
