using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Application.Helpers;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using System.Collections.Generic;

namespace BookStore.Application.Services
{
    public class OrderItemService
        : CrudService<CreateOrderItemDto, UpdateOrderItemDto, OrderItemDto, OrderItem>, IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _orderItemRepository = repository;
            _mapper = mapper;
        }

        public override void Add(CreateOrderItemDto dto)
        {
            Helper.CheckId(dto.OrderId, "Order");
            Helper.CheckId(dto.BookId, "Book");
            base.Add(dto);
        }

        public override void Update(UpdateOrderItemDto dto)
        {
            Helper.CheckId(dto.Id, "Order Item");
            Helper.CheckId(dto.OrderId, "Order");
            Helper.CheckId(dto.BookId, "Book");
            base.Update(dto);
        }

        public override IEnumerable<OrderItemDto> GetAll()
        {
            var items = _orderItemRepository.GetAllWithDetails();
            return _mapper.Map<List<OrderItemDto>>(items);
        }

        public override OrderItemDto? GetById(int id)
        {
            var item = _orderItemRepository.GetByIdWithDetails(id);
            if (item == null) return null;
            return _mapper.Map<OrderItemDto>(item);
        }
    }
}