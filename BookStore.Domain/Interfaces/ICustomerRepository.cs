using BookStore.Domain.Entities;
using System.Collections.Generic;

namespace BookStore.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        List<Order> GetOrders(int customerId);
        List<Customer> GetAllWithOrders();
        Customer? GetByIdWithOrders(int id);
    }
}