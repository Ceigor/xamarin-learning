using QuotesApp.Exception;
using QuotesApp.Model;
using QuotesApp.ViewModel.Base;
using System.Diagnostics;
using System.Threading.Tasks;

namespace QuotesApp.ViewModel
{
    class QuoteViewModel : BaseViewModel
    {
        private Quote quote;
        public Quote Quote
        {
            get { return quote; }
            private set
             {
                if (quote != value)
                {
                    quote = value;
                    Debug.WriteLine("Setting quote to new value!");
                    RaisePropertyChanged(() => Quote);
                }
            }
        }

        public override Task InitializeAsync(object quote)
        {
            if(!(quote is Quote))
            {
                var actualType = quote == null ? null : quote.GetType();
                throw new InvalidTypeException(typeof(Quote), actualType);
            }
            Quote = quote as Quote;
            Debug.WriteLine("Initializing quote");
            return base.InitializeAsync(quote);
        }

    }

}
