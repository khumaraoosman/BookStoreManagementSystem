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
    public class CustomerService
    : CrudService<CreateCustomerDto, UpdateCustomerDto, CustomerDto, Customer>, ICustomerService
    {
        public CustomerService(IRepository<Customer> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

        public override void Add(CreateCustomerDto dto)
        {
            Helper.CheckString(dto.Name, "Customer Name");
            Helper.CheckString(dto.Address, "Address");

            base.Add(dto);
        }

        public override void Update(UpdateCustomerDto dto)
        {
            Helper.CheckId(dto.Id, "Customer");
            Helper.CheckString(dto.Name, "Customer Name");
            Helper.CheckString(dto.Address, "Address");

            base.Update(dto);
        }
    }
}
