using QuotesApp.Exception;
using QuotesApp.Message;
using QuotesApp.Model;
using QuotesApp.Service.Abstraction;
using QuotesApp.View;
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
        public ICommand HideCommand { get; private set; }
        public ICommand QuoteSelectedCommand { get; private set; }
        private IQuoteService QuoteService;
        private bool quoteChanged;
        public bool QuoteChanged
        {
            get { return quoteChanged; }
            private set
            {
                quoteChanged = value;
                RaisePropertyChanged(() => QuoteChanged);
            }
        }
        private Quote changedQuote;
        public Quote ChangedQuote
        {
            get { return changedQuote; }
            private set
            {
                changedQuote = value;
                RaisePropertyChanged(() => ChangedQuote);
            }
        }
        private ObservableCollection<Quote> quotes;
        public ObservableCollection<Quote> Quotes
        {
            get { return quotes; }
            private set
            {
                quotes = value;
                RaisePropertyChanged(() => Quotes);
            }
        }

        private void SetSubscription()
        {
            MessagingCenter.Subscribe<QuoteViewModel, Quote>(
               this, MessagesKeys.QUOTE_CHANGED, (sender, arg) =>
               {
                   Debug.WriteLine("Same thing using messages!" + arg);
               });
        }


        public QuotesViewModel(IQuoteService quoteService)
        {
            QuoteService = quoteService;
            HideCommand = new Command(() => QuoteChanged = false);
            QuoteSelectedCommand = new Command(async (quote) => await GoToQuoteAsync(quote));
            SetQuotesAsync();
        }

        private async void SetQuotesAsync()
        {
            var quotesFromService = await QuoteService.GetQuotesAsync();
            var quotes = new ObservableCollection<Quote>();
            quotesFromService.ForEach(quotes.Add);
            Quotes = quotes;
        }

        private async Task GoToQuoteAsync(object quote)
        {
            if (quote == null)
                return;
            if (!(quote is Quote))
                    throw InvalidTypeException.CreateExpectedActualException(typeof(Quote), quote?.GetType());
            await navigationService.NavigateToAsync<QuoteView, QuoteViewModel>((quote as Quote).Id);
        }

        public void SetChanged(object changedQuoteId)
        {
            if (!(changedQuoteId is int))
                InvalidTypeException.CreateExpectedActualException(typeof(int), changedQuoteId?.GetType());
            SetChangedQuote((int)changedQuoteId);
        }

        //null hack with listView.SelectedItem = null ....
        private async void SetChangedQuote(int quoteId)
        {
            var changedQuote = await QuoteService.GetQuoteAsync(quoteId);
            for (int i = 0; i < Quotes.Count; i++)
                if (Quotes[i] == null || Quotes[i].Id == quoteId)
                {
                    Debug.WriteLine(String.Format("Strange, Found Quote['{0}'] = '{1}'", i, Quotes[i]));
                    Quotes[i] = changedQuote;
                }
            ChangedQuote = changedQuote;
            QuoteChanged = true;
        }
    }
}
