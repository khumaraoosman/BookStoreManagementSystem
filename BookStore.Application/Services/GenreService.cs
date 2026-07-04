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

    public class GenreService
    : CrudService<CreateGenreDto, UpdateGenreDto, GenreDto, Genre>, IGenreService
    {
        public GenreService(IRepository<Genre> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

        public override void Add(CreateGenreDto dto)
        {
            Helper.CheckString(dto.Name, "Genre Name");

            base.Add(dto);
        }

        public override void Update(UpdateGenreDto dto)
        {
            Helper.CheckId(dto.Id, "Genre");
            Helper.CheckString(dto.Name, "Genre Name");

            base.Update(dto);
        }
    }
}
