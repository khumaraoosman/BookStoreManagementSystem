using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; } = null!;
       
        public string Address { get; set; } = null!;
        public List<Order> Orders { get; set; } = [];

    }
}
