using BookStore.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Interfaces
{
    public interface ICrudService<TCreateDto, TUpdateDto, TDto,TEntity>
    {
        void Add(TCreateDto createDto);
        void Update(TUpdateDto updateDto);
        IEnumerable<TDto> GetAll();
        void Delete(int id);
        TDto? GetById(int id);

    }
}
