using System.Collections.Generic;
using BareBonesEnterprise.Model;
using BareBonesEnterprise.Service.Abstraction;

namespace BareBonesEnterprise.Service.Implementation
{
    class QuoteService : IQuoteService
    {
        public List<Quote> GetQuotes()
        {
            var quotes = new List<Quote>();
            quotes.Add(new Quote("Potentialy too long quote", "Ayn Rand"));
            quotes.Add(new Quote("Potentialy too short quote", "Aristoteles"));
            return quotes;
        }
    }
}
