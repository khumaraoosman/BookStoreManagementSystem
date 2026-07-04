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
        public AuthorService(IRepository<Author> repository, IMapper mapper)
       : base(repository, mapper)
        {
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
    }

}
