using System;
using System.Collections.Generic;
using System.Text;

namespace QuotesApp.Exception
{
    class InvalidTypeException : ApplicationException
    {
        private InvalidTypeException(Type expectedType, Type actualType) : base($"Expected type {expectedType} but was {actualType}")
        {

        }

        public static InvalidTypeException CreateExpectedActualException(Type expectedType, Type actualType)
        {
            return new InvalidTypeException(expectedType, actualType);
        }
    }
}
