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
    public class OrderItemService : CrudService<CreateOrderItemDto, UpdateOrderItemDto, OrderItemDto, OrderItem>, IOrderItemService
    {
        private readonly IMapper _mapper;

        public OrderItemService(IRepository<OrderItem> repository, IMapper mapper) : base(repository, mapper)
        {
            _mapper = mapper;
        }

        public override async Task<OrderItemDto> AddAsync(CreateOrderItemDto dto)
        {
            Helper.CheckId(dto.OrderId, "Order");
            Helper.CheckId(dto.BookId, "Book");

            return await base.AddAsync(dto);
        }
    }
}
