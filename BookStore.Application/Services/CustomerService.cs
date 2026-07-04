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
    public class CustomerService : CrudService<CreateCustomerDto, UpdateCustomerDto, CustomerDto, Customer>, ICustomerService
    {
        private readonly IMapper _mapper;

        public CustomerService(IRepository<Customer> repository, IMapper mapper) : base(repository, mapper)
        {
            _mapper = mapper;

        }
        public override async Task<CustomerDto> AddAsync(CreateCustomerDto dto)
        {
            Helper.CheckString(dto.Name, "Name");
            Helper.CheckString(dto.Address, "Address");

            return await base.AddAsync(dto);
        }



    }
}
