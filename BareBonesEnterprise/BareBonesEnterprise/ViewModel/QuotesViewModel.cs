using BareBonesEnterprise.Model;
using BareBonesEnterprise.Service.Abstraction;
using BareBonesEnterprise.Service.Implementation;
using BareBonesEnterprise.ViewModel.Base;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BareBonesEnterprise.ViewModel
{
    class QuotesViewModel : BaseViewModel
    {
        private IQuoteService quoteService;
        private ObservableCollection<Quote> quotes;
        public ObservableCollection<Quote> Quotes
        {
            get { return quotes; }
            private set
            {
                if(quotes != value)
                {
                    quotes = value;
                    Console.WriteLine("Setting quotes to new value!");
                    RaisePropertyChanged(() => Quotes);
                }
            }
        }

        public QuotesViewModel(IQuoteService quoteService)
        {
            this.quoteService = quoteService;
            var quotes = new ObservableCollection<Quote>();
            quoteService.GetQuotes().ForEach(quotes.Add);
            Quotes = quotes;
        }
    }
}
