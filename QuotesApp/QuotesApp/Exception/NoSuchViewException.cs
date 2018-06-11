using System;

namespace QuotesApp.Exception
{
    class NoSuchViewException : ApplicationException
    {
        public NoSuchViewException()
        {

        }

        public NoSuchViewException(string viewName) : base("There is no view of name:" + viewName)
        {

        }

        public NoSuchViewException(Type viewType) : base("There is no view of type:" + viewType)
        {

        }
    }
}
