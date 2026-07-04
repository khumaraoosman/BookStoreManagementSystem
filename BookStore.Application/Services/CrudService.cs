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
    public class CrudService<TCreateDto, TUpdateDto, TDto, TEntity>
    : ICrudService<TCreateDto, TUpdateDto, TDto, TEntity>
    where TEntity : BaseEntity
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public CrudService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual void Add(TCreateDto createDto)
        {
            var entity = _mapper.Map<TEntity>(createDto);
            _repository.Add(entity);
        }

        public virtual IEnumerable<TDto> GetAll()
        {
            var entities = _repository.GetAll();
            return _mapper.Map<List<TDto>>(entities);
        }

        public virtual TDto? GetById(int id)
        {
            var entity = _repository.GetById(id);

            if (entity == null)
                return default;

            return _mapper.Map<TDto>(entity);
        }

        public virtual void Update(TUpdateDto updateDto)
        {
            var entity = _mapper.Map<TEntity>(updateDto);
            _repository.Update(entity);
        }

        public virtual void Delete(int id)
        {
            var entity = _repository.GetById(id);

            if (entity == null)
                throw new Exception("Data not found.");

            _repository.Delete(entity);
        }
    }


}
