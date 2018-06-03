using System;

namespace BareBonesEnterprise.Exception
{
    class NoSuchViewException : ApplicationException
    {
        public NoSuchViewException()
        {

        }

        public NoSuchViewException(string viewName) : base("There is no view of name:" + viewName)
        {

        }
    }
}
