using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Application.Helpers;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using System.Collections.Generic;

namespace BookStore.Application.Services
{
    public class GenreService
        : CrudService<CreateGenreDto, UpdateGenreDto, GenreDto, Genre>, IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _genreRepository = repository;
            _mapper = mapper;
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

        public override IEnumerable<GenreDto> GetAll()
        {
            var genres = _genreRepository.GetAllWithBooks();
            return _mapper.Map<List<GenreDto>>(genres);
        }

        public override GenreDto? GetById(int id)
        {
            var genre = _genreRepository.GetByIdWithBooks(id);
            if (genre == null) return null;
            return _mapper.Map<GenreDto>(genre);
        }
    }
}