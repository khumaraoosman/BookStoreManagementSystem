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
    public class OrderService : CrudService<CreateOrderDto, UpdateOrderDto, OrderDto, Order>, IOrderService
    {
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> repository, IMapper mapper) : base(repository, mapper)
        {
            _mapper = mapper;
        }

        public override async Task<OrderDto> AddAsync(CreateOrderDto dto)
        {
            Helper.CheckId(dto.CustomerId, "Customer");

            return await base.AddAsync(dto);
        }
    }
}
