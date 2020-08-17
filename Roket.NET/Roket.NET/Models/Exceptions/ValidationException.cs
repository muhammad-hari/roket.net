using System;

namespace Roket.NET
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}
