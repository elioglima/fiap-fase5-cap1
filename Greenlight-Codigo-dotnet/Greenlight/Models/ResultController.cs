using System.Collections.Generic;

namespace Greenlight.Models
{
    public class ResultController<T>
    {
        private string message;

        public ResultController(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }

        public ResultController(T data)
        {
            Data = data;
        }

        public ResultController(List<string> errors)
        {
            Errors = errors;
        }

        public ResultController(string error)
        {
            Errors.Add(error);
        }

        public ResultController(string error, string message) : this(error)
        {
            this.message = message;
        }
        
        public T Data { get; private set; }

        public List<string> Errors { get; private set; } = new();
    }
}