using System;

namespace QuotesApp.Exception
{
    class NoSuchViewModelException : ApplicationException
    {
        public NoSuchViewModelException(string viewModelName) : base("There is no viewModel of name:" + viewModelName)
        {
            
        }
    }
}
