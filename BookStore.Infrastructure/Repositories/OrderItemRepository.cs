using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(BookStoreDbContext context)
       : base(context)
        {
        }
        public List<OrderItem> GetAllWithDetails()
        {
            return _context.OrderItems
                .Include(x => x.Order)
                .Include(x => x.Book)
                .ToList();
        }

        public OrderItem? GetByIdWithDetails(int id)
        {
            return _context.OrderItems
                .Include(x => x.Order)
                .Include(x => x.Book)
                .FirstOrDefault(x => x.Id == id);
        }

        
        public List<OrderItem> GetByOrderId(int orderId)
        {
            return _context.OrderItems
                .Where(x => x.OrderId == orderId)
                .ToList();
        }

      
        public List<OrderItem> GetByBookId(int bookId)
        {
            return _context.OrderItems
                .Where(x => x.BookId == bookId)
                .ToList();
        }

        
    }
}
