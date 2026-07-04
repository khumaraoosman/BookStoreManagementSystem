using BookStore.Application.DTOs;
using BookStore.Application.Services;
using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Interfaces
{
    public interface ICustomerService
    : ICrudService<CreateCustomerDto, UpdateCustomerDto, CustomerDto, Customer>
    {
    }

}
