using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Services
{
    public class CrudService<TCreateDto, TUpdateDto, TDto, TEntity> : ICrudService<TCreateDto, TUpdateDto, TDto,TEntity> where TEntity : BaseEntity
    {
        
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public CrudService(IRepository<TEntity> repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;

        }
        public virtual Task<TDto> AddAsync(TCreateDto dto)
        {
            throw new NotImplementedException();
        }
        public void Add(TCreateDto createDto) 
        {
            throw new NotImplementedException();
        }
        public void Update(TUpdateDto updateDto) 
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<TDto> GetAll() 
        {
            throw new NotImplementedException();
        }
        public TDto GetById(int id)
        {
            throw new NotImplementedException();
        }
    }

   
}
