using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Domain.Entities;
using System.Linq;

namespace BookStore.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ===== BOOK =====
            CreateMap<Book, BookDto>()
                .ForMember(x => x.AuthorName,
                    opt => opt.MapFrom(src => src.Author == null ? string.Empty : src.Author.FullName))
                .ForMember(x => x.GenreName,
                    opt => opt.MapFrom(src => src.Genre == null ? string.Empty : src.Genre.Name));
            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();

            // ===== AUTHOR =====
            CreateMap<Author, AuthorDto>()
                .ForMember(x => x.BookNames,
                    opt => opt.MapFrom(src => src.Books == null ? Enumerable.Empty<string>() : src.Books.Select(b => b.Name)));
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<UpdateAuthorDto, Author>();

            // ===== GENRE =====
            CreateMap<Genre, GenreDto>()
                .ForMember(x => x.BookNames,
                    opt => opt.MapFrom(src => src.Books == null ? Enumerable.Empty<string>() : src.Books.Select(b => b.Name)));
            CreateMap<CreateGenreDto, Genre>();
            CreateMap<UpdateGenreDto, Genre>();

            // ===== CUSTOMER =====
            CreateMap<Customer, CustomerDto>()
                .ForMember(x => x.OrderIds,
                    opt => opt.MapFrom(src => src.Orders == null ? Enumerable.Empty<int>() : src.Orders.Select(o => o.Id)));
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, Customer>();

            // ===== ORDER =====
            CreateMap<Order, OrderDto>()
                .ForMember(x => x.CustomerName,
                    opt => opt.MapFrom(src => src.Customer == null ? string.Empty : src.Customer.Name))
                .ForMember(x => x.BookNames,
                    opt => opt.MapFrom(src => src.OrderItems == null
                        ? Enumerable.Empty<string>()
                        : src.OrderItems.Select(oi => oi.Book != null ? oi.Book.Name : string.Empty)));
            CreateMap<CreateOrderDto, Order>();
            CreateMap<UpdateOrderDto, Order>();

            // ===== ORDER ITEM =====
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(x => x.BookName,
                    opt => opt.MapFrom(src => src.Book == null ? string.Empty : src.Book.Name));
            CreateMap<CreateOrderItemDto, OrderItem>();
            CreateMap<UpdateOrderItemDto, OrderItem>();
        }
    }
}