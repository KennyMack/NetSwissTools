using NetSwissTools.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetSwissTools.Services.Interfaces
{
    public interface IErrorBaseService
    {
        List<ModelException> Errors { get; set; }
    }
}
