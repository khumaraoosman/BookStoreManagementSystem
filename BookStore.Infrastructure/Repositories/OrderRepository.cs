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


    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(BookStoreDbContext context)
            : base(context)
        {
        }

        // Bütün sifarişləri müştəri və sifariş elementləri ilə birlikdə gətirir
        public List<Order> GetAllWithDetails()
        {
            return _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.OrderItems)
                .ToList();
        }

        // Id-yə görə sifarişi bütün məlumatları ilə birlikdə gətirir
        public Order? GetByIdWithDetails(int id)
        {
            return _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.OrderItems)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Order> GetCustomerOrders(int customerId)
        {
            throw new NotImplementedException();
        }

        // Müştərinin bütün sifarişlərini gətirir
        public List<Order> GetOrdersByCustomer(int customerId)
        {
            return _context.Orders
                .Where(x => x.CustomerId == customerId)
                .ToList();
        }

        // Tarixə görə sifarişləri gətirir
        public List<Order> GetOrdersByDate(DateTime date)
        {
            return _context.Orders
                .Where(x => x.OrderDate.Date == date.Date)
                .ToList();
        }

        // Qiymət aralığına görə sifarişlər
        public List<Order> GetOrdersByTotalPrice(double minPrice, double maxPrice)
        {
            return _context.Orders
                .Where(x => x.TotalPrice >= minPrice &&
                            x.TotalPrice <= maxPrice)
                .ToList();
        }

        public decimal GetTotalPrice(int orderId)
        {
            throw new NotImplementedException();
        }

    }
}
