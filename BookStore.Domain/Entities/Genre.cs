using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; } = [];
    }
}
