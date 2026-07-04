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
    public class AuthorService : CrudService<CreateAuthorDto, UpdateAuthorDto, AuthorDto, Author>, IAuthorService
    {
        private readonly IMapper _mapper;


        public AuthorService(IRepository<Author> repository, IMapper mapper) : base(repository, mapper)
        {
            _mapper = mapper;
        }
        public override async Task<AuthorDto> AddAsync(CreateAuthorDto dto)
        {
            Helper.CheckString(dto.FullName, "Author Name");

            return await base.AddAsync(dto);
        }



    }

}
