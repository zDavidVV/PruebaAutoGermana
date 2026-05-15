using Autogermana.Application.Interfaces;
using Autogermana.Domain.DTOs;
using Autogermana.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiAutogermana.Controllers
{
    /// <summary>
    /// Controlador API para operaciones relacionadas con clientes.  
    /// </summary>
    /// <remarks>Ruta base: Api/Customer. Inyecta ICustomerService para obtener datos de cliente e
    /// IErrorService para el manejo centralizado de errores; captura excepciones y devuelve 200 OK con el resultado o
    /// 400 BadRequest con el error procesado.</remarks>
    [ApiController]
    [Route("Api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IErrorService _errorService;
        public CustomerController(ICustomerService customerService, IErrorService errorService)
        {
            _customerService = customerService;
            _errorService = errorService;
        }

        /// <summary>
        ///  Endpoint de consulta de detalles del cliente, recibe un objeto CustomerRequestDto con el Id del cliente y retorna un objeto Customer con los detalles del cliente
        /// </summary>
        /// <param name="customer"></param>
        /// <remarks>Ejemplo de customer
        /// 
        ///     CustomerId = "123"
        /// 
        /// </remarks>
        /// <response code="400">Error interno del aplicativo</response>
        /// <response code="500">Error del servidor</response>
        /// <response code="600">Error desconcido</response>
        [HttpPost]
        [Route("CustomerDetail")]
        public async Task<ActionResult> CustomerDetail([FromBody] CustomerRequestDto customer)
        {
            try
            {
                var result = await _customerService.GetCustomerDetailsAsync(customer);
                return Ok(result);
            }
            catch(Exception ex)
            {
                var error = _errorService.HandleError(ex);
                return BadRequest(error);
            }
        }

    }
}
