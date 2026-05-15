using System;
using System.Collections.Generic;
using System.Text;

namespace Autogermana.Domain.Entities
{
    public class Customer
    {
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public int age { get; set; }
        public string email { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
    }
}
