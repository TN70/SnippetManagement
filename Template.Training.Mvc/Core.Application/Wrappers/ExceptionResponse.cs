using System;
using System.Collections.Generic;

namespace Core.Application.Wrappers
{
    public class ExceptionResponse<T>
    {
        public bool Succeeded { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public List<Exception> Errors { get; set; } = new List<Exception>();
        public ExceptionResponse()
        {
        }
    }
}
