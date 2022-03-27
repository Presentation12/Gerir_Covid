using System;

namespace Exceptions
{
    public class InvalidIntException : ApplicationException
    {
        public InvalidIntException() : base("Numero introduzido invalido!!!") { }
        public InvalidIntException(string s) : base(s) { }
        public InvalidIntException(string s, Exception e)
        {
            throw new InvalidIntException(e.Message + " - " + s);
        }
    }
}
