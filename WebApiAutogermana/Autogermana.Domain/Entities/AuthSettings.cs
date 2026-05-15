using System;
using System.Collections.Generic;
using System.Text;

namespace Autogermana.Domain.Entities
{
    public class AuthSettings
    {
        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
        public string TenantId { get; set; } = string.Empty;
    }

    public class TokenAuth
    {
        public string access_token { get; set; } = string.Empty;
        public string token_type { get; set; } = string.Empty;

    }
}
