using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Application.Helpers;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using System.Collections.Generic;

namespace BookStore.Application.Services
{
    public class CustomerService
        : CrudService<CreateCustomerDto, UpdateCustomerDto, CustomerDto, Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _customerRepository = repository;
            _mapper = mapper;
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

        public override IEnumerable<CustomerDto> GetAll()
        {
            var customers = _customerRepository.GetAllWithOrders();
            return _mapper.Map<List<CustomerDto>>(customers);
        }

        public override CustomerDto? GetById(int id)
        {
            var customer = _customerRepository.GetByIdWithOrders(id);
            if (customer == null) return null;
            return _mapper.Map<CustomerDto>(customer);
        }
    }
}