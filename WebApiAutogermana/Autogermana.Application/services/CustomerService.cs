using Autogermana.Application.Interfaces;
using Autogermana.Domain.DTOs;
using Autogermana.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autogermana.Application.services
{
    public class CustomerService: ICustomerService
    {
        private readonly IPowerService _powerService;

        public CustomerService(IPowerService powerService)
        {
            _powerService = powerService;
        }

        public async Task<Customer> GetCustomerDetailsAsync(CustomerRequestDto customer)
        {
            if(string.IsNullOrEmpty(customer.CustomerId))
            {
                throw new ArgumentException("CustomerId se encuentra vacio.");
            }

            return await _powerService.GetCustomerDetailsAsync(customer);
        }
    }
}
