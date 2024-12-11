using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Result
{
    public class Result<T>
    {
        public T? Value { get; set; }
        public bool Error { get; set; }
        public string? Message { get; set; } = string.Empty;

        public static Result<T> Succes(T value, string? message = null) => new Result<T> { Value = value, Error = false ,Message = message };
        public static Result<T> Failure(string? message) =>new Result<T> { Value = default, Error = true, Message = message };
    }

}
