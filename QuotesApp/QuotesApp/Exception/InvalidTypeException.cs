using System;
using System.Collections.Generic;
using System.Text;

namespace QuotesApp.Exception
{
    class InvalidTypeException : ApplicationException
    {
        public InvalidTypeException(Type expectedType, Type actualType) : base($"Expected type {expectedType} but was {actualType}")
        {

        }
    }
}
