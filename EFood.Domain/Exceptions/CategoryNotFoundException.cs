using System;

namespace EFood.Domain.Exceptions
{
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException() { }
        public CategoryNotFoundException(string message) : base(message) { }
        public CategoryNotFoundException(string message, Exception inner)
        : base(message, inner) { }
    }
}
