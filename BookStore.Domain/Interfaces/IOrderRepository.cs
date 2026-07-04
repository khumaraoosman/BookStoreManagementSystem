using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BookStore.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order> GetAllWithDetails();
        Order? GetByIdWithDetails(int id);
        List<Order> GetOrdersByCustomer(int customerId);
        List<Order> GetOrdersByDate(DateTime date);
        List<Order> GetOrdersByTotalPrice(double minPrice, double maxPrice);
        decimal GetTotalPrice(int orderId);
    }
}