using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Application.Helpers;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using System.Collections.Generic;

namespace BookStore.Application.Services
{
    public class AuthorService : CrudService<CreateAuthorDto, UpdateAuthorDto, AuthorDto, Author>, IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _authorRepository = repository;
            _mapper = mapper;
        }

        public override void Add(CreateAuthorDto dto)
        {
            Helper.CheckString(dto.FullName, "Author Name");
            base.Add(dto);
        }

        public override void Update(UpdateAuthorDto dto)
        {
            Helper.CheckId(dto.Id, "Author");
            Helper.CheckString(dto.FullName, "Author Name");
            base.Update(dto);
        }

        public override IEnumerable<AuthorDto> GetAll()
        {
            var authors = _authorRepository.GetAllWithBooks();
            return _mapper.Map<List<AuthorDto>>(authors);
        }

        public override AuthorDto? GetById(int id)
        {
            var author = _authorRepository.GetByIdWithBooks(id);
            if (author == null) return null;
            return _mapper.Map<AuthorDto>(author);
        }
    }
}