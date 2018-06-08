using QuotesApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuotesApp.Service.Abstraction
{
    interface IQuoteService
    {
        List<Quote> GetQuotes();
        Task<List<Quote>> GetQuotesAsync();
        Task<Quote> GetQuoteAsync(int quoteId);
        Task<int> SaveQuoteAsync(Quote quote);
    }
}
