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
    

    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(BookStoreDbContext context)
            : base(context)
        {
        }

        // Bütün müştəriləri sifarişləri ilə birlikdə gətirir
        public List<Customer> GetAllWithOrders()
        {
            return _context.Customers
                .Include(x => x.Orders)
                .ToList();
        }

        // Id-yə görə müştərini sifarişləri ilə birlikdə gətirir
        public Customer? GetByIdWithOrders(int id)
        {
            return _context.Customers
                .Include(x => x.Orders)
                .FirstOrDefault(x => x.Id == id);
        }

        // Ada görə müştəri axtarışı
        public List<Customer> SearchByName(string name)
        {
            return _context.Customers
                .Where(x => x.Name.Contains(name))
                .ToList();
        }

        // Müştərinin sifarişlərini gətirir
        public List<Order> GetCustomerOrders(int customerId)
        {
            return _context.Orders
                .Where(x => x.CustomerId == customerId)
                .ToList();
        }

        public List<Order> GetOrders(int customerId)
        {
            throw new NotImplementedException();
        }

       
    }

}
