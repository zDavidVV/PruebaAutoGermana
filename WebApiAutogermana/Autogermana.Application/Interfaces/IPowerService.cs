using Autogermana.Domain.DTOs;
using Autogermana.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autogermana.Application.Interfaces
{
    public interface IPowerService
    {
        Task<Customer> GetCustomerDetailsAsync(CustomerRequestDto customer);
    }
}
