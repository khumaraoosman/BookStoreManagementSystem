using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity 
    { 
        void Add(T entity); 
        void Update(T entity); 
        void Delete(T entity); T GetById(int id);
        List<T> GetAll();
    }

}

