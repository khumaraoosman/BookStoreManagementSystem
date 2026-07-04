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
    public class OrderService
    : CrudService<CreateOrderDto, UpdateOrderDto, OrderDto, Order>, IOrderService
    {
        public OrderService(IRepository<Order> repository, IMapper mapper)
            : base(repository, mapper)
        {
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
    }
}
