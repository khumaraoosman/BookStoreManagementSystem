using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
       
        
            List<OrderItem> GetAllWithDetails();

            OrderItem? GetByIdWithDetails(int id);

            List<OrderItem> GetByOrderId(int orderId);

            List<OrderItem> GetByBookId(int bookId);
        
    }
}
