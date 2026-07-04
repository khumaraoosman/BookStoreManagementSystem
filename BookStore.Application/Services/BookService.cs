using BookStore.Application.DTOs;
using BookStore.Application.Helpers;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Services
{
    public class BookService : CrudService<CreateBookDto, UpdateBookDto, BookDto, Book>, IBookService
    {

        private readonly IMapper _mapper;

        public BookService(IRepository<Book> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public override async Task<BookDto> AddAsync(CreateBookDto dto)
        {
            Helper.CheckString(dto.Name, "Book Name");
            Helper.CheckPrice(dto.Price);
            Helper.CheckId(dto.AuthorId, "Author");
            Helper.CheckId(dto.GenreId, "Genre");

            return await base.AddAsync(dto);
        }

    }
    

}
