using Autogermana.Domain.Entities;
using Autogermana.Domain.DTOs;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using Autogermana.Application.Interfaces;

namespace Autogermana.Infrastructure
{
    public class PowerService: IPowerService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthSettings _Configuration;

        public PowerService(HttpClient httpClient, IOptions<AuthSettings> configuration)
        {
            _httpClient = httpClient;
            _Configuration = configuration.Value;
        }

        public async Task<Customer> GetCustomerDetailsAsync(CustomerRequestDto customer)
        {
            var token = await GetTokenAsync();

            var url = "https://powerautomate.ejerciciosenior.prueba.api.powerplatform.com:100/invokeflow/";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsJsonAsync(url, customer);

            if(!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Error al obtener los detalles del cliente");
            }

            var content = await response.Content.ReadFromJsonAsync<Customer>();

            if(content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            return content;
        }

        private async Task<string> GetTokenAsync() 
        {
            var parameters = new Dictionary<string, string>
            {
                { "client_id", _Configuration.ClientId },
                { "client_secret", _Configuration.ClientSecret },
                { "tenant_id", _Configuration.TenantId },
                { "grant_type", "client_credentials" }
            };
        
            var url = $"https://login.microsoftonline.com/{_Configuration.TenantId}/oauth2/v2.0/token";

            var response = await _httpClient.PostAsync(url, new FormUrlEncodedContent(parameters));

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Error al obtener el token");
            }

            var content = await response.Content.ReadFromJsonAsync<TokenAuth>();

            if(content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            return content.access_token;
        }
    }
}
