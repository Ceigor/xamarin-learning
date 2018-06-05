using QuotesApp.Exception;
using QuotesApp.Model;
using QuotesApp.ViewModel.Base;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

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
        public ICommand SaveQuoteCommand { get; private set; }

        public QuoteViewModel()
        {
            SaveQuoteCommand = new Command(async() => await QuoteSavedAsync());
        }

        public override Task InitializeAsync(object quote)
        {
            if(!(quote is Quote))
                throw InvalidTypeException.CreateExpectedActualException(typeof(Quote), quote?.GetType());
            Quote = quote as Quote;
            return base.InitializeAsync(quote);
        }

        private async Task QuoteSavedAsync()
        {
            Debug.WriteLine("Would save quote: " +Quote);
            await navigationService.RemoveCurrentFromBackStackAsync();
        }

    }

}
