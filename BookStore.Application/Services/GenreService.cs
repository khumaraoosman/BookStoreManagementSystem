using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Application.Helpers;
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

    public class GenreService : CrudService<CreateGenreDto, UpdateGenreDto, GenreDto, Genre>, IGenreService
    {
        private readonly IMapper _mapper;

        public GenreService(IRepository<Genre> repository, IMapper mapper) : base(repository, mapper)
        {
            _mapper = mapper;
        }

        public override async Task<GenreDto> AddAsync(CreateGenreDto dto)
        {
            Helper.CheckString(dto.Name, "Genre Name");
         

            return await base.AddAsync(dto);
        }
    }
}
