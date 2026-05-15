using System;
using System.Collections.Generic;
using System.Text;

namespace Autogermana.Domain.Entities
{
    public class ErrorResponse
    {
        public int statusCode { get; set; }
        public string message { get; set; } = string.Empty;
    }
}
