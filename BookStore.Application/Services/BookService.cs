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
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;


        public BookService(IBookRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _bookRepository = repository;
            _mapper = mapper;
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
        public override IEnumerable<BookDto> GetAll()
        {
            var books = _bookRepository.GetAllWithDetails();
            return _mapper.Map<List<BookDto>>(books);
        }

        public override BookDto? GetById(int id)
        {
            var book = _bookRepository.GetByIdWithDetails(id);
            if (book == null) return null;
            return _mapper.Map<BookDto>(book);
        }
    }


    
}
