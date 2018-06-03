using BareBonesEnterprise.Exception;
using BareBonesEnterprise.Model;
using BareBonesEnterprise.ViewModel.Base;
using System;
using System.Threading.Tasks;

namespace BareBonesEnterprise.ViewModel
{
    class QuoteViewModel : BaseViewModel
    {
        public Quote Quote { get; private set; }

        public override Task InitializeAsync(object quote)
        {
            if(!(quote is Quote))
            {
                var actualType = quote == null ? null : quote.GetType();
                throw new InvalidTypeException(typeof(Quote), actualType);
            }
            return Task.FromResult(Quote = quote as Quote);
        }

    }

}
