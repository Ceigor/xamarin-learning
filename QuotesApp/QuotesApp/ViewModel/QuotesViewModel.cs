using QuotesApp.Exception;
using QuotesApp.Model;
using QuotesApp.Service.Abstraction;
using QuotesApp.ViewModel.Base;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuotesApp.ViewModel
{
    class QuotesViewModel : BaseViewModel, IEditableItemViewModel
    {
        public ICommand QuoteSelectedCommand { get; private set; }
        private IQuoteService quoteService;
        private ObservableCollection<Quote> quotes;
        public ObservableCollection<Quote> Quotes
        {
            get { return quotes; }
            private set
            {
                quotes = value;
                Console.WriteLine("Setting quotes to new value!");
                RaisePropertyChanged(() => Quotes);
            }
        }
      

        public QuotesViewModel(IQuoteService quoteService)
        {
            this.quoteService = quoteService;
            var quotes = new ObservableCollection<Quote>();
            quoteService.GetQuotes().ForEach(quotes.Add);
            Quotes = quotes;
            QuoteSelectedCommand = new Command(async (quote) => await QuoteAsync(quote));
        }

        private async Task QuoteAsync(object quote)
        {
            await navigationService.NavigateToAsync<QuoteViewModel>(quote);
        }

        public void SetChanged(object changed)
        {
            if (!(changed is Quote))
            {
                InvalidTypeException.CreateExpectedActualException(typeof(Quote), changed?.GetType());
            }
            var quote = changed as Quote;
            var indexOfQuote = quotes.IndexOf(quote);
            Debug.WriteLine("Index of edited quote = " + indexOfQuote);
            Debug.WriteLine("Would change quote = " + Quotes[indexOfQuote]);
            Quotes[indexOfQuote] = new Quote(quote.Content, quote.Author);
            /*//TODO learn how to do this correctly!
            var newQuotes = new ObservableCollection<Quote>();
            for(int i = 0; i < Quotes.Count; i++)
                newQuotes.Add(Quotes[i]);
            Quotes = newQuotes;*/
        }
    }
}
