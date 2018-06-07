using System;
using System.Collections.Generic;
using QuotesApp.Model;
using QuotesApp.Service.Abstraction;

namespace QuotesApp.Service.Implementation
{
    class QuoteService : IQuoteService
    {
        private readonly int MOCKED_QUOTES = 100;
        private readonly Random RANDOM = new Random();

        public List<Quote> GetQuotes()
        {
            return MockQuotes();
        }

        private List<Quote> MockQuotes()
        {
            var quotes = new List<Quote>();
            var quotesToPopulateQuotes = new List<Quote>()
            {
                new Quote("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus. Phasellus pharetra nulla ac diam. Quisque semper justo at risus. Donec venenatis, turpis vel hendrerit interdum, dui ligula ultricies purus, sed posuere libero dui id orci. Nam congue, pede vitae dapibus aliquet, elit magna vulputate arcu, vel tempus metus leo non est. Etiam sit amet lectus quis est congue mollis. Phasellus congue lacus eget neque. Phasellus ornare, ante vitae consectetuer consequat, purus sapien ultricies dolor, et mollis pede metus eget nisi. Praesent sodales velit quis augue. Cras suscipit, urna at aliquam rhoncus, urna quam viverra nisi, in interdum massa nibh nec erat.", "Cycero"),
                new Quote("The premisses of demonstrative knowledge must be true, primary, immediate, more knowable than and prior to the conclusion, which is further related to them as effect to cause... The premisses must be the cause of the conclusion, more knowable than it, and prior to it; its causes, since we posses scientific knowledge of a thing only when we know its cause; prior, in order to be causes; antecedently known, this antecedent knowledge being not our mere understanding of the meaning, but knowledge of the fact as well. Now 'prior' and 'more knowable' are ambiguous terms, for there is a difference between what is prior and more knowable in the order of being and what is prior and knowable to man. I mean that objects nearer to sense are prior and more knowable to man; objects without qualification prior and more knowable are those further from sense. Now the most universal causes are furthest from sense and particular causes are nearest to sense, and they are thus exactly opposed to each other", "Aristotle"),
                new Quote("The natural way of doing this [seeking scientific knowledge or explanation of fact] is to start from the things which are more knowable and obvious to us and proceed towards those which are clearer and more knowable by nature; for the same things are not 'knowable relatively to us' and 'knowable' without qualification. So in the present inquiry we must follow this method and advance from what is more obscure by nature, but clearer to us, towards what is more clear and more knowable by nature. Now what is to us plain and obvious at first is rather confused masses, the elements and principles of which became known to us by later analysis..", "Aristotle"),
                new Quote("That particular sense of sacred rapture men say they experience in contemplating nature- I've never received it from nature, only from. Buildings, Skyscrapers. I would give the greatest sunset in the world for one sight of New York's skyline. The shapes and the thought that made them. The sky over New York and the will of man made visible. What other religion do we need? And then people tell me about pilgrimages to some dank pest-hole in a jungle where they go to do homage to a crumbling temple, to a leering stone monster with a pot belly, created by some leprous savage. Is it beauty and genius they want to see? Do they seek a sense of the sublime? Let them come to New York, stand on the shore of the Hudson, look and kneel. When I see the city from my window - no, I don't feel how small I am - but I feel that if a war came to threaten this, I would like to throw myself into space, over the city, and protect these buildings with my body.", "Ayn Rand"),
                new Quote("No single one can possess greater wisdom than the many scholars who are elected by all the men for their wisdom. Yet we can. We do. We have fought against saying it, but now it is said. We do not care. We forget all men, all laws and all things save our metals and our wires. So much is still to be learned! So long a road lies before us, and what care we if we must travel it alone!.", "Ayn Rand"),
                new Quote("The individual has always had to struggle to keep from being overwhelmed by the tribe. If you try it, you will be lonely often, and sometimes frightened. But no price is too high to pay for the privilege of owning yourself.", "Friedrich Nietzsche")

            };
            for (int i = 0; i < MOCKED_QUOTES; i++)
                quotes.Add(GetRandomQuote(quotesToPopulateQuotes));
            return quotes;
        }

        private Quote GetRandomQuote(List<Quote> quotes)
        {
            var randomQuote = quotes[RANDOM.Next(0, quotes.Count)];
            return new Quote(randomQuote.Content, randomQuote.Author);
        }
    }
}
