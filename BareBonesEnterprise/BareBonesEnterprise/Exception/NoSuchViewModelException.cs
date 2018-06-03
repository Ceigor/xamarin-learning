using System;

namespace BareBonesEnterprise.Exception
{
    class NoSuchViewModelException : ApplicationException
    {
        public NoSuchViewModelException(string viewModelName) : base("There is no viewModel of name:" + viewModelName)
        {
            
        }
    }
}
