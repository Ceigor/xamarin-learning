using System.Collections.Generic;
using BareBonesEnterprise.Model;
using BareBonesEnterprise.Service.Abstraction;

namespace BareBonesEnterprise.Service.Implementation
{
    class QuoteService : IQuoteService
    {
        private readonly int MOCKED_QUOTES = 100;
            
        public List<Quote> GetQuotes()
        {
            return MockQuotes();
        }

        private List<Quote> MockQuotes()
        {
            var quotes = new List<Quote>();
            var quoteToPopulateQuotes = new Quote("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus. Phasellus pharetra nulla ac diam. Quisque semper justo at risus. Donec venenatis, turpis vel hendrerit interdum, dui ligula ultricies purus, sed posuere libero dui id orci. Nam congue, pede vitae dapibus aliquet, elit magna vulputate arcu, vel tempus metus leo non est. Etiam sit amet lectus quis est congue mollis. Phasellus congue lacus eget neque. Phasellus ornare, ante vitae consectetuer consequat, purus sapien ultricies dolor, et mollis pede metus eget nisi. Praesent sodales velit quis augue. Cras suscipit, urna at aliquam rhoncus, urna quam viverra nisi, in interdum massa nibh nec erat.", "Cycero");
            for (int i = 0; i < MOCKED_QUOTES; i++)
                quotes.Add(quoteToPopulateQuotes);
            return quotes;
        }
    }
}
