using Autogermana.Application.Interfaces;
using Autogermana.Application.services;
using Autogermana.Domain.Entities;
using Autogermana.Domain.DTOs;
using Autogermana.Infrastructure;
using Microsoft.Extensions.Options;

namespace TestAutogermana
{
    public class UnitTest1
    {
        private readonly HttpClient _httpClient;
        private readonly ICustomerService _customerService;
        readonly IOptions<AuthSettings> _authSettings;
        private readonly PowerService _powerService;

        public UnitTest1()
        {
            _authSettings = Options.Create(new AuthSettings
            {
                ClientId = "your-client-id",
                ClientSecret = "your-client",
                TenantId = "your-tenant-id"
            });
            _httpClient = new HttpClient();
            _powerService = new PowerService(_httpClient, _authSettings); 
            _customerService = new CustomerService(_powerService);
           
        }
        [Fact]
        public async Task Test1()
        {
            var customerRequest = new CustomerRequestDto { CustomerId = "123" };

            var result = await _customerService.GetCustomerDetailsAsync(customerRequest);

            Assert.NotNull(result);
            Assert.Equal("John", result.firstName);
            Assert.True(result.age > 0);

        }
    }
}
