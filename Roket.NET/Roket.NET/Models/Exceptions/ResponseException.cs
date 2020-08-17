using System;

namespace Roket.NET
{
    public class ResponseException : Exception
    {
        public ResponseException(string message) : base(message) { }
    }
}
