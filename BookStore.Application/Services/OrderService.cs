using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Application.Helpers;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using System.Collections.Generic;

namespace BookStore.Application.Services
{
    public class OrderService
        : CrudService<CreateOrderDto, UpdateOrderDto, OrderDto, Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _orderRepository = repository;
            _mapper = mapper;
        }

        public override void Add(CreateOrderDto dto)
        {
            Helper.CheckId(dto.CustomerId, "Customer");
            base.Add(dto);
        }

        public override void Update(UpdateOrderDto dto)
        {
            Helper.CheckId(dto.Id, "Order");
            Helper.CheckId(dto.CustomerId, "Customer");
            base.Update(dto);
        }

        public override IEnumerable<OrderDto> GetAll()
        {
            var orders = _orderRepository.GetAllWithDetails();
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public override OrderDto? GetById(int id)
        {
            var order = _orderRepository.GetByIdWithDetails(id);
            if (order == null) return null;
            return _mapper.Map<OrderDto>(order);
        }
    }
}