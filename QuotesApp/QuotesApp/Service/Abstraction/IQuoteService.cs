using QuotesApp.Model;
using System.Collections.Generic;

namespace QuotesApp.Service.Abstraction
{
    interface IQuoteService
    {
        List<Quote> GetQuotes();
    }
}
