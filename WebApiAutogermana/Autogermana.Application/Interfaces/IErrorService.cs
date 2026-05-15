using Autogermana.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autogermana.Application.Interfaces
{
    public interface IErrorService
    {
        ErrorResponse HandleError(Exception ex);
    }
}
