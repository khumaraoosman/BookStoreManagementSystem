using BookStore.Domain.Entities;
using System.Collections.Generic;

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