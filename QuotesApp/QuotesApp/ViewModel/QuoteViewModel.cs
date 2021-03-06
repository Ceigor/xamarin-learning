﻿using QuotesApp.Exception;
using QuotesApp.Message;
using QuotesApp.Model;
using QuotesApp.Service.Abstraction;
using QuotesApp.ViewModel.Base;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuotesApp.ViewModel
{
    class QuoteViewModel : BaseViewModel, IDetailViewModel
    {
        private Quote initialQuote;
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
        public IQuoteService QuoteService { get; private set; }

        public QuoteViewModel(IQuoteService quoteService)
        {
            QuoteService = quoteService;
            SaveQuoteCommand = new Command(async() => await SaveQuoteAsync());
        }


        private async Task SaveQuoteAsync()
        {
            Debug.WriteLine("Would save quote: " +Quote);
            if (Quote.Equals(initialQuote))
            {
                MessagingCenter.Send(this, MessagesKeys.NOTHING_CHANGED);
                return;
            }
            var id = await QuoteService.SaveQuoteAsync(Quote);
            Debug.WriteLine("Saved quote, id = " + id);
            MessagingCenter.Send(this, MessagesKeys.QUOTE_CHANGED, Quote);
            await navigationService.RemoveCurrentFromBackStackAsync(id);
        }

        public async void SetDetailId(object id)
        {
            Debug.WriteLine("Searching quote....");
            Quote = await QuoteService.GetQuoteAsync((int)id);
        }
    }

}
