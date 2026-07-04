using BookStore.Application.DTOs;
using BookStore.Application.Helpers;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BookStore.Application.Services;
using BookStore.Domain.Interfaces;
using AutoMapper;

namespace BookStore.Application.Services
{
   
        public class BookService
            : CrudService<CreateBookDto, UpdateBookDto, BookDto, Book>, IBookService
        {
            public BookService(IRepository<Book> repository, IMapper mapper)
                : base(repository, mapper)
            {
            }

            public override void Add(CreateBookDto dto)
            {
                Helper.CheckString(dto.Name, "Book Name");
                Helper.CheckPrice(dto.Price);
                Helper.CheckId(dto.AuthorId, "Author");
                Helper.CheckId(dto.GenreId, "Genre");

                base.Add(dto);
            }

            public override void Update(UpdateBookDto dto)
            {
                Helper.CheckId(dto.Id, "Book");
                Helper.CheckString(dto.Name, "Book Name");
                Helper.CheckPrice(dto.Price);
                Helper.CheckId(dto.AuthorId, "Author");
                Helper.CheckId(dto.GenreId, "Genre");

                base.Update(dto);
            }
        }


    
}
